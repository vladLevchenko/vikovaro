using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Interfaces
{
    public interface IAppUserModule
    {
        void SaveUserInfoPoints(List<InfoPoint> infoPoints);
        List<InfoPoint> GetSavedUserInfoPoints();
    }
}
