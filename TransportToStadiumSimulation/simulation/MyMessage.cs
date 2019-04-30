using OSPABA;

namespace simulation
{
    public class MyMessage : MessageForm
    {
        public MyMessage(Simulation sim) :
            base(sim)
        {
        }

        public MyMessage(MyMessage original) :
            base(original)
        {
            // copy() is called in superclass
        }

        public override MessageForm CreateCopy()
        {
            return new MyMessage(this);
        }

        protected override void Copy(MessageForm message)
        {
            base.Copy(message);
            var original = (MyMessage) message;
            // Copy attributes
        }
    }
}