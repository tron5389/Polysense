﻿using PS.Shared.Models;
using PS.UI.Shared.Clients;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PS.UI.Shared.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        private readonly PoliticianClient httpClient;

        public TestViewModel(PoliticianClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IEnumerable<Politician> Politicians { get; set; }

        public override async Task OnUpdate(CancellationToken token)
        {
            await GetPoliticians(token);
        }

        private async Task GetPoliticians(CancellationToken token)
        {
            Politicians = await httpClient.GetPoliticians(token);
        }
    }
}