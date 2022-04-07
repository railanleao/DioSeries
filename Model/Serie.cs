using DioSeries.Model.EnumClass;

namespace DioSeries.Model
{
    public class Serie : EntidadeBase
    {
        private EGenero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        
        //MétododConstrutor
        public Serie(int id, EGenero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorna = " ";
            retorna += $"Gênero: {this.Genero}{Environment.NewLine}";
            retorna += $"Título: {this.Titulo}{Environment.NewLine}";
            retorna += $"Descrição: {this.Descricao}{Environment.NewLine}";
            retorna += $"Ano de Início: {this.Ano}{Environment.NewLine}";
            retorna += $"Excluída: {this.Excluido}";
            return retorna;
        }
            //Encapsulamento: retorna método
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}