using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Azure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConnectedBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AI : ControllerBase
    {
        public HttpClient HttpClient { get; }

        public AI(IHttpClientFactory factory)
        {
            HttpClient = factory.CreateClient();
        }
        // GET: api/<AI>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var payload = new
            {
                contents =  new object[] { 
                    new {
                        parts = new object[]{ 
                            new {text = "hey there"}
                        } 
                    }
                }
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string key = "AIzaSyC3oIqcuDqV7bQ_Y50lzw0p5x18mgjq9rg";
            //HttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your_access_token");

            var res = await HttpClient.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={key}", content);
            var responseString = await res.Content.ReadAsStringAsync();


            return Ok(new { status = res.StatusCode, response = responseString });
        }

        // GET api/<AI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
