using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacPresentation.Backend
{
    public interface IService
    {
        int Calculate(int customerId, int programId, string operationName);
    }
}
