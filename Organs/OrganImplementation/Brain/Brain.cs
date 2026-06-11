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

        public Brain() : base(OrganNames.Brain, "Brain")
        {
            _meninges = new Meninges();
            _cerebrum = new Cerebrum();
            _cerebellum = new Cerebellum();
            _brainstem = new Brainstem();
            _diencephalon = new Diencephalon();
            _limbicSystem = new LimbicSystem();
            _signalBoard = new BrainSignalBoard();
        }

        public override void Tick(double deltaTime)
        {
            _meninges.Tick(deltaTime, _signalBoard);
            _cerebrum.Tick(deltaTime, _signalBoard);
            _diencephalon.Tick(deltaTime, _signalBoard);
            _cerebellum.Tick(deltaTime, _signalBoard);
            _limbicSystem.Tick(deltaTime, _signalBoard);
            _brainstem.Tick(deltaTime, _signalBoard);
        }
    }
}
