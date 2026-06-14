using System;
using System.Collections.Generic;
using System.Text;

using Physiology.Organs;
using Physiology.Damage;

namespace Physiology.Organs.OrganImplementation.Brain
{
    public class Brain : Organ
    {
        private Meninges _meninges;
        private Cerebrum _cerebrum;
        private Cerebellum  _cerebellum;
        private Brainstem _brainstem;
        private Diencephalon _diencephalon;
        private LimbicSystem _limbicSystem;
        private BrainSignalBoard  _signalBoard;
        
        private OrganPathology _pathology;
        private OrganStates _state;

        public Brain() : base(OrganNames.Brain, "Brain")
        {
            _meninges = new Meninges();
            _cerebrum = new Cerebrum();
            _cerebellum = new Cerebellum();
            _brainstem = new Brainstem();
            _diencephalon = new Diencephalon();
            _limbicSystem = new LimbicSystem();
            _signalBoard = new BrainSignalBoard();
            _signalBoard.ResetToHealthy();
        }

        public override void Tick(double deltaTime)
        {
            _meninges.Tick(deltaTime, _signalBoard);
            _cerebrum.Tick(deltaTime, _signalBoard);
            _diencephalon.Tick(deltaTime, _signalBoard);
            _cerebellum.Tick(deltaTime, _signalBoard);
            _limbicSystem.Tick(deltaTime, _signalBoard);
            _brainstem.Tick(deltaTime, _signalBoard);
            
            // update state
            if (
                _meninges.OverallHealth > 0.8 &&
                _cerebrum.OverallHealth > 0.8 &&
                _diencephalon.OverallHealth > 0.8 &&
                _limbicSystem.OverallHealth > 0.8 &&
                _brainstem.OverallHealth > 0.8)
            {
                _state = OrganStates.Healthy;
            }
            else
            {
                // scan sub organs and update pathology
                _pathology =
                    _brainstem.Pathology |
                    _cerebrum.Pathology |
                    _cerebellum.Pathology |
                    _diencephalon.Pathology |
                    _limbicSystem.Pathology |
                    _meninges.Pathology;
            }
        }
    }
}
