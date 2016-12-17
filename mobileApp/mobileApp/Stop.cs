namespace mobileApp
{
    class Stop
    {

        public string Name
        {
            get;
            set;
        }

        public Stop DirectsTo
        {
            get;
            set;
        }

        public Stop(string name)
        {
            Name = name;
        }

        
        //further properites might be added
    }
}