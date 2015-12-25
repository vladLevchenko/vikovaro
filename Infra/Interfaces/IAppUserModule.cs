using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Interfaces
{
    public interface IAppUserModule
    {
		NetworkUser User { get; }
		
		void SetCurrentUser (string id, string token);

		List<InfoPoint> UserInfoPoints { get; set; }

		bool IsAuthenticated { get; }
    }
}
