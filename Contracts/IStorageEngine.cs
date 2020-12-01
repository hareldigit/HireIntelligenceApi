using System;
using System.Data;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStorageEngine
    {
        DataTable GetCumulativeViews(CumulativeViewsParameters parameters);
    }
}
