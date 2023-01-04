using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;


namespace Questao2
{
    internal class PartidaCliente
    {
        public async Task<int> GetTotalScoredGoalsAsync(string team, int year)
        {
            PartidaRequest request = new PartidaRequest
            {
                Team1 = team,
                Year = year
            };

            IEnumerable<Partida> PartidaHome = await GetPartidaAsync(request);

            request = new PartidaRequest
            {
                Team2 = team,
                Year = year
            };

            IEnumerable<Partida> footballMatchesAway = await GetPartidaAsync(request);

            return PartidaHome.Sum(x => x.Team1Goals) + footballMatchesAway.Sum(x => x.Team2Goals);
        }

        private async Task<List<Partida>> GetPartidaAsync(PartidaRequest request)
        {
            int page = 1;

            request.Page = page;

            List<Partida> footballMatches = new();

            PartidaResponse response = await GetFootballMatchesByPageAsync(request);

            footballMatches.AddRange(response.Data);

            while (page < response.TotalPages)
            {
                page++;

                request.Page = page;

                response = await GetFootballMatchesByPageAsync(request);

                footballMatches.AddRange(response.Data);
            }

            return footballMatches;
        }

        private async Task<PartidaResponse> GetFootballMatchesByPageAsync(PartidaRequest request)
        {
            try
            {
                string requestUri = GetUriWithQueryParams(request);

                using HttpClient httpClient = new HttpClient();

                string responseBody = await httpClient.GetStringAsync(requestUri);

                PartidaResponse response = JsonConvert.DeserializeObject<PartidaResponse>(responseBody);

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        private string GetUriWithQueryParams(PartidaRequest request)
        {
            string url = "https://jsonmock.hackerrank.com/api/football_matches";

            UriBuilder uriBuilder = new UriBuilder(url);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (request.Year != null)
                query["year"] = request.Year.ToString();

            if (request.Team1 != null)
                query["team1"] = request.Team1;

            if (request.Team2 != null)
                query["team2"] = request.Team2;

            if (request.Page != null)
                query["page"] = request.Page.ToString();

            uriBuilder.Query = query.ToString();

            return Uri.EscapeUriString(uriBuilder.ToString());
        }
    }
}
