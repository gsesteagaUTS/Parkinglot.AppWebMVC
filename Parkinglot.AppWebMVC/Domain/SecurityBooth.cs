using System;

namespace Parkinglot.AppWebMVC.Domain
{
    public class SecurityBooth
    {
        public ContainmentBar ContainmentBarEntry { get; private set; }
        public ContainmentBar ContainmentBarExit { get; private set; }
    
        public SecurityBooth()
        {
            
        }

        public SecurityBooth(ContainmentBar containmentBarEntry, ContainmentBar containmentBarExit)
        {
            ContainmentBarEntry = containmentBarEntry;
            ContainmentBarExit = containmentBarExit;
        }
    }
}
