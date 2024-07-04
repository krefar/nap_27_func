using System.Data;

public interface IDatabaseService
{
    DataTable GetCitizenData(string pasportHash);
}