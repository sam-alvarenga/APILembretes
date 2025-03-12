using Microsoft.AspNetCore.Mvc;
using PrjAPILembretes.Context;
using PrjAPILembretes.DTO;
using PrjAPILembretes.Entities;
using System.Text.Json;
using System.Xml.Linq;


namespace PrjAPILembretes.Controllers
{
    [ApiController]//Passo 2 - Colocar a anotation
    [Route("[Controller]")]
    public class LembreteController : ControllerBase
    {
        //criar a classe controller para lembrete e definir todas as rotas CRUD (all, get, put, delete e post). Lembre-se que o lembrete será atualizado e deletado através  

        //Readonly = Uma proprietade somente leitura 
        private readonly AppLembretesContext _contextDB;

        public LembreteController(AppLembretesContext contextDB)
        {
            _contextDB = contextDB;
        }

        [HttpPost]
        public IActionResult addLembrete(Lembrete lembrete) //receber um lembrete
        {
            _contextDB.Add(lembrete);//Adiconando o lembrete no banco
            _contextDB.SaveChanges(); //Salvando as alterações no banco de dados
            return Ok(); //retornando o lembrete adicionado

        }

        [HttpGet("get/{id}")]

        public IActionResult getLembrete(int id) //receber o id do lembrete a ser exibido
        {
            var lembrete = _contextDB.Lembretes.Find(id); //PEsquisar entre os lembretes do contexto aquele que posssui o id recebido, guardando o lembrete na variável

            if (lembrete == null) //verificando se foi encontrado algumm lembrete
            {
                return NotFound(); //se não encontrado, retornará erro 404 - Not Found
            }
            return Ok(lembrete); // se for encontrado, retornará o próprio lembrete
        }

        [HttpPut("update/{id}")]

        public IActionResult UpdateLembrete( int id,  Lembrete lembrete)
        {
           
            
            var atualizarLembrete = _contextDB.Lembretes.Find(id); //Buscar o id no banco

            if (atualizarLembrete == null)  // verificar se o lembrete foi encontrado
            {
                return NotFound();  //caso contrário erro 404
            }

            atualizarLembrete.Titulolembrete = lembrete.Titulolembrete; //pega os dados antigos e atualiza pelo novo
            atualizarLembrete.CorpoLembrente = lembrete.CorpoLembrente; //pega os dados antigos e atualiza pelo novo
            atualizarLembrete.StatusLembrete = lembrete.StatusLembrete; //pega os dados antigos e atualiza pelo novo

            _contextDB.Lembretes.Update(atualizarLembrete);

            _contextDB.SaveChanges(); //Salvando as alterações no banco de dados

            return Ok(atualizarLembrete); // atualizar

          
        }
    }
}