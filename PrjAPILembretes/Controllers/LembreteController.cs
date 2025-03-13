using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjAPILembretes.Context;
using PrjAPILembretes.DTO;
using PrjAPILembretes.Entities;

using System.Text.Json;
using System.Xml.Linq;


namespace PrjAPILembretes.Controllers
{
    [ApiController]//Passo 2 - Colocar a anotation da controller
    [Route("[Controller]")]
    public class LembreteController : ControllerBase // Herdar de ControllerBase
    {
        //criar a classe controller para lembrete e definir todas as rotas CRUD (all, get, put, delete e post). Lembre-se que o lembrete será atualizado e deletado através  

        //Readonly = Uma proprietade somente leitura 

        //Adicionar uma referencia ao contexto do banco criado na "context" para manipular no código
        private readonly AppLembretesContext _contextDB;

        public LembreteController(AppLembretesContext contextDB)
        {
            _contextDB = contextDB;
        }

        //rota estática
        [HttpPost]
        public IActionResult addLembrete(Lembrete lembrete) //receber um lembrete
        {
            _contextDB.Add(lembrete);//Adiconando o lembrete no banco
            _contextDB.SaveChanges(); //Salvando as alterações no banco de dados
            return Ok(); //retornando o lembrete adicionado

        }

        //verbo + Rota dinâmica (com parâmentro)
        [HttpGet("get/{id}")] //rota dinâmica

        //IActionResult: usado apenas no mvc. Ela é usada para representar o resultado de uma ação dentro de um controlador, ou seja, o que será retornado para o cliente após o processamento de uma solicitação HTTP.

        public IActionResult getLembrete(int id) //receber o id do lembrete a ser exibido
        {
            var lembrete = _contextDB.Lembretes.Find(id); //Pesquisar entre os lembretes do contexto aquele que posssui o id recebido, guardando o lembrete na variável

            if (lembrete == null) //verificando se foi encontrado algumm lembrete
            {
                return NotFound(); //se não encontrado, retornará erro 404 - Not Found
            }
            return Ok(lembrete); // se for encontrado, retornará o próprio lembrete
        }

        //Passo 1 - Denifir verbo e se há parâmetro de rota dinâmica
        [HttpPut("update/{id}")]

        public IActionResult UpdateLembrete( int id,  Lembrete lembrete)
        {
           
            
            var atualizarLembrete = _contextDB.Lembretes.Find(id); //Buscar o id no banco. Acessa a tabela lembretes "_contextDB.Lembretes"
            //FIND: O Find retorna apenas o primeiro item que atende à condição. Se você precisar de todos os itens que atendem ao critério, pode usar o FindAll

            if (atualizarLembrete == null)  // verificar se o lembrete foi encontrado
            {
                return NotFound();  //caso contrário erro 404
            }

            atualizarLembrete.Titulolembrete = lembrete.Titulolembrete; //pega os dados antigos e atualiza pelo novo
            atualizarLembrete.CorpoLembrente = lembrete.CorpoLembrente; //pega os dados antigos e atualiza pelo novo
            atualizarLembrete.StatusLembrete = lembrete.StatusLembrete; //pega os dados antigos e atualiza pelo novo

            _contextDB.Lembretes.Update(atualizarLembrete);

            _contextDB.SaveChanges(); //Salvando as alterações no banco de dados

            return Ok(atualizarLembrete); // retorna o lembrete atualizado


        }

        [HttpDelete("del/{id}")]

        public IActionResult DeleteLembrete(int id)
        {
           var deletarLembrete = _contextDB.Lembretes.Find(id);

            if (deletarLembrete == null)
            {
                return NotFound();
            }

            _contextDB.Lembretes.Remove(deletarLembrete);

            _contextDB.SaveChanges();

            return Ok (deletarLembrete); 

        }

        [HttpGet("get/all")]

        public  IActionResult GetLembreteAll()
        {
            var listaLembrete = _contextDB.Lembretes.ToList(); //Retorna todos os lembretes
                         
            return Ok(listaLembrete); 

        }
           

        

    }
}