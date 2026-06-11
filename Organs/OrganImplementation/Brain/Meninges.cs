using Physiology.Damage;

namespace Physiology.Organs.OrganImplementation.Brain;

public class Meninges
{
    // Dura mater, Arachnoid mater, Pia mater and Ventricles status
    
    public double DuraIntegrity { get; set; } = 1.0;
    public double ArachnoidIntegrity { get; set; } = 1.0;
    public double PiaIntegrity { get; set; } = 1.0;

    
    // Bleeding types
    public double EpiduralBleedingVolume { get; set; }   // mL
    public double SubduralBleedingVolume { get; set; }
    public double SubarachnoidBleedingVolume { get; set; }
    
    // Inflammation (meningitis)
    public double InflammationLevel { get; set; } = 0.0;   // 0..1
    
    // CSF pressure relative to normal (mmHg)
    public double IntracranialPressureDelta { get; set; } = 0.0;  // +extra mmHg
    
    // Called every frame by Brain.Tick()
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        // Resorption of small bleeds (healing factor)
        double healingRate = 0.1 * deltaTime;   // per second
        EpiduralBleedingVolume = Math.Max(0, EpiduralBleedingVolume - healingRate);
        SubduralBleedingVolume = Math.Max(0, SubduralBleedingVolume - healingRate);
        SubarachnoidBleedingVolume = Math.Max(0, SubarachnoidBleedingVolume - healingRate);
        
        // Update intracranial pressure based on bleed volume + inflammation
        // tissue fluid rushes to head when inflammation burst, that is inflammation storm
        double totalBleed = EpiduralBleedingVolume + SubduralBleedingVolume + SubarachnoidBleedingVolume;
        IntracranialPressureDelta = (totalBleed / 50.0) + (InflammationLevel * 15.0);
        
        // Inflammation can increase spontaneously if infection present (simplified)
        InflammationLevel = Math.Max(0, InflammationLevel - 0.05 * deltaTime); // slow decay
        
        // Feed signals to the Brain's signal board
        signalBoard.IntracranialPressureDelta = IntracranialPressureDelta;
        signalBoard.MeningealInflammation = InflammationLevel;
        signalBoard.HasSubarachnoidHemorrhage = SubarachnoidBleedingVolume > 10;
        
        // If inflammation high, trigger cytokine signals
        if (InflammationLevel > 0.7)
        {
            signalBoard.Interleukin6 = Math.Min(1.0, signalBoard.Interleukin6 + 0.1 * deltaTime);
        }
    }

}