using System;
using System.Runtime.InteropServices;

namespace Contract
{
    [ComVisible(true)]
    [Guid(ContractGuids.ServerClass)]
    [ComDefaultInterface(typeof(IServer))]
    public class Server : IServer
    {
        //dummy Server, only needed for .tlb-Generation
        public double ComputePi() => throw new NotImplementedException();
        public double RealPi { get; set; }
        public string Name { get; set; }
    }
}
