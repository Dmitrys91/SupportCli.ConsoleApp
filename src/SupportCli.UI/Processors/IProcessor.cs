using System.Threading.Tasks;

namespace SupportCli.UI.Processors
{
    public interface IProcessor 
    {
        /// <summary>
        /// Start process
        /// </summary>
        /// <returns></returns>
        Task StartAsync();
    }
}
