using Microsoft.AspNetCore.Mvc;//Passo 1 - Importar a biblioteca MVC
using PrjAPILembretes.models;
using PrjAPILembretes.DTO;
using System.Text.Json;



namespace PrjAPILembretes.Controllers
{
    [ApiController]//Passo 2 - Colocar a anotation
    [Route("[controller]")]
    public class PessoaController : ControllerBase//Passo 3 - Herdar de controllerbase
    {

        [HttpGet("pessoaSample")]//Passo 4 - Definir o verbo que acessa a rota e o nome da rota que será exposto

        //public Pessoa GetPessoa(string name, int idade)//Passo 5 - Criar o método que atende a rota
        //{
        //    Pessoa pessoa = new Pessoa(name, idade);
        //    return pessoa;
        //}

        [HttpGet("all")]
        public List<Pessoa> GetAll()
        {
            return Pessoa.Pessoas;
        }
        //[HttpPost("add")]
        //public Pessoa InserirPessoa(string name, int age)
        //{
        //    Pessoa pessoa = new Pessoa(name, age); //mandou info para a Model
        //                                           //mandar a info para o Array                                         
        //    return pessoa;
        //}

        [HttpPost("addperson")] //rota estática
        public IActionResult AddPerson(PessoaDTO personDTO)
        {
            //DTO data Transfer Object

            Pessoa newPerson;
            try
            {
                newPerson = new Pessoa(personDTO.NomePessoa, personDTO.IdadePessoa);
                newPerson.InserirPessoa();

            }
            catch (Exception ex)
            {

                return BadRequest(JsonSerializer.Serialize($"Erro:{ex.Message}"));
            }
            return Ok(newPerson);
        }


        [HttpGet("get/{name}")]//rota dinamica
        public IActionResult GetPerson(string name)
        {

            Pessoa person;

            try
            {
                Pessoa personSearch = new Pessoa(name);
                person = personSearch.BuscarPessoaPeloNome();
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize($"Erro{ex.Message}"));
            }
            return Ok(person);
        }

        [HttpDelete("del/{name}")]
        public IActionResult DeletePerson(string name)
        {
            Pessoa person;
            try
            {
                person = new Pessoa(name);
                person.BuscarPessoaPeloNome().RemoverPessoa();
            }
            catch (Exception ex)
            {
                return BadRequest(JsonSerializer.Serialize($"Erro{ex.Message}"));
            }
            return Ok(person);
        }

        [HttpPut("update/{name}")]

        public IActionResult UpdatePerson(PessoaDTO personDTO, string name) 
        {

            Pessoa person;

            try
            {
                person = new Pessoa(personDTO.NomePessoa, personDTO.IdadePessoa);
                person.AtualizarPessoa(name);
            }
            catch (Exception ex)
            {

                return BadRequest(JsonSerializer.Serialize($"Erro{ex.Message}"));
            }

            return Ok(person);  


        }
    }
}
