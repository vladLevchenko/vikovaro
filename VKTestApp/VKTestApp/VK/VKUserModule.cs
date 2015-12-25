using System;
using Infra.Interfaces;
using Infra.Data;
using VKTestApp.VK;
using System.Collections.Generic;

namespace VKTestApp.VK
{
	public class VKUserModule:IAppUserModule
	{
		public NetworkUser User { get; set; } 

		public List<InfoPoint> UserInfoPoints{ get; set; }

		public VKUserModule ()
		{
		}

		public void SetCurrentUser(string id, string token)
		{
			User = new VKUser { ID = id, Token = token };
		}

		public bool IsAuthenticated
		{
			get { return User != null; }
		}

	
	}
}

