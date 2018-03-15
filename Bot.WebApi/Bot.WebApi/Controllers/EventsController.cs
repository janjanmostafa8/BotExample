﻿using System.Threading.Tasks;
using System.Web.Http;
using Bot.App.Events;
using Bot.App.RequestProcessors.Events;
using Bot.WebApi.Tools;
using Newtonsoft.Json.Linq;

namespace Bot.WebApi.Controllers
{
	public class EventsController: ApiController
	{
		[HttpPost]
        public async Task<IHttpActionResult> Fire([FromBody]JToken content)
		{
			var resp = await new MainEventsRequestProcessor(new AuthService(),
					new EventsRequestProcessor(new EventsProcessor(), Properties.Settings.Default.Token))
				.ProcessAsync(content.ToString());
            return this.JsonString(resp);
        }
	}
}