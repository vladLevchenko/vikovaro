using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ISocialModule
    {
        void SetCurrentUser(string id, string token);
        List<InfoPoint> GetInfoPointsByIds(List<int> Ids);
        List<InfoPoint> SearchInfoPoints(string searchString);
        List<InfoPoint> GetUserInfoPoints();

        bool IsAuthenticated { get; }
            
    }
}
