using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStorageManager
    {
        IEnumerable<CumulativeView> GetCumulativeViews(CumulativeViewsParameters searchParameters);
    }
}