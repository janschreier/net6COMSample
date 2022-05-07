using System.Runtime.InteropServices;
using Contract;

namespace COMServer;

[ComVisible(true)]
[Guid(ContractGuids.ServerClass)]
[ComDefaultInterface(typeof(IServer))]
public class Server : IServer
{
    public double ComputePi() => Math.PI;
    public double RealPi { get; set; } = 3;
    public string Name { get; set; } = "Peter";
}