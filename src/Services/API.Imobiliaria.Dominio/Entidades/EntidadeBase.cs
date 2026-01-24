namespace API.Imobiliaria.Dominio.Entidades
{
    public class EntidadeBase
    {
        public Guid Id { get; protected set; }
        public bool Excluido { get; protected set; }
        public DateTime DataRegistro { get; protected set; }
        public DateTime? DataAtualizacaoRegistro { get; protected set; }
        public DateTime? DataExclusao { get; protected set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public void Criar()
        {
            DataRegistro = DateTime.UtcNow;
            Excluido = false;
        }

        public void Desativar()
        {
            if (Excluido) return;

            Excluido = true;
            DataExclusao = DateTime.UtcNow;
        }

        public void AtualizarDataAtualizacao()
        {
            DataAtualizacaoRegistro = DateTime.UtcNow;
        }
    }
}
