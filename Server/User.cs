using System.Threading.Tasks;

namespace webapi
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public interface IFilter
    {
        Task Filter();
    }

    public abstract class AbstractFilter : IFilter
    {
        public abstract Task Filter();
    }

    public class ConcreteFilter : AbstractFilter
    {
        public override Task Filter()
        {
            return Task.CompletedTask;
        }
    }


}