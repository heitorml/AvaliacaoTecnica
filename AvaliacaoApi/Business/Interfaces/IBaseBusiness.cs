namespace AvaliacaoApi.Business.Interfaces
{
    public interface IBaseBusiness<T>
    {
        string ErrosRequisicao { get; set; }
        string ErrosValidacao { get; set; }
    }
}