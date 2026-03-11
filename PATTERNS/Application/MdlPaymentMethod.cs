using PATTERNS.Interfaces;

namespace PATTERNS.Application;

public class MdlPaymentMethod : IPaymentMethod
{
    public string Name => "Mdl";
    public bool Pay(decimal amount) => amount > 0;
}

