using System;
using System.Collections.Generic;
using System.Text;

using Physiology.Core;

namespace Physiology.Regulation
{
    /// <summary>
    /// Overall HomeostasisBus that stabilize the body
    /// </summary>
    public class HomeostasisBus
    {
        private readonly NeuralRegulator _neural;
        private readonly HumoralRegulator _humoral;
        private readonly ImmuneRegulator _immune;

        public HomeostasisBus(GlobalPhysiologyBoard board) {
            _neural = new NeuralRegulator(board);
            _humoral = new HumoralRegulator(board);
            _immune = new ImmuneRegulator(board);
        }

        public void Update(double deltaTime){
            _neural.Update(deltaTime);
            _humoral.Update(deltaTime);
            _immune.Update(deltaTime);
        }
    }
}
