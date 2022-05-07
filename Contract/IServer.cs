using System.Runtime.InteropServices;

namespace Contract
{

    [ComVisible(true)]
    [Guid(ContractGuids.ServerInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServer
    {
        /// <summary>
        /// Compute the value of the constant Pi.
        /// </summary>
        double ComputePi();
        double RealPi { get; set; }
        string Name { get; set; }
    }
}
