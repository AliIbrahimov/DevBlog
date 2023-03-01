namespace Entity.ViewModels.Statistic;

public class StatisticGetVM
{
    public int Id { get; set; }
    public int HappyClients { get; set; }
    public string? HappyClientsIcon { get; set; }
    public int ProjectsDone { get; set; }
    public string? ProjectsDoneIcon { get; set; }
    public int WinAwards { get; set; }
    public string? WinAwardsIcon { get; set; }
}
