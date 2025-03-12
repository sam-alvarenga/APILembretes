namespace PrjAPILembretes.DTO
{
    public class PessoaDTO
    {
        //Os atributos não precisa ser o mesmo nome que está na model e db. Seriam os nomes que vão mostrar na tela.
        public string ?NomePessoa { get; set;} 
        public int IdadePessoa { get; set; }
    }
}
