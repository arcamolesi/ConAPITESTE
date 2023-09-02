using ConAPITESTE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConAPITESTE.Controllers
{
    public class AlunosController : Controller
    {
        // GET: AlunosController
        public ActionResult Index()
        {
            IEnumerable<Aluno> alunos = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7254/api/Alunos");

                //HTTP GET
                var responseTask = client.GetAsync("alunos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Aluno>>();
                    readTask.Wait();
                    alunos = readTask.Result;
                }
                else
                {
                    alunos = Enumerable.Empty<Aluno>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
               
            }
            return View(alunos);
        }

        // GET: AlunosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlunosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,nome,disciplina,nota1, nota2,")] Aluno aluno)
        {
            try
            {
                if (aluno != null)
                {
                    // teste de git
                    int x = 10;
                    int y = 20;
                    int soma = x + y;
                    Console.WriteLine(soma); 

                    using (var client = new HttpClient())
                    {
                        // client.BaseAddress = new Uri("https://localhost:7074/api/Produtos");
                        //HTTP POST
                        string url = "https://localhost:7254/api/Alunos";
                        aluno.id = 0;
                        var dataAsString = JsonConvert.SerializeObject(aluno);
                        var content = new StringContent(dataAsString);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var postTask = client.PostAsync(url, content);

                        postTask.Wait();


                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }


                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
