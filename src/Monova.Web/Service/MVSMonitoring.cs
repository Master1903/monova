using System.Threading;
using System.Threading.Tasks;
using Monova.Entity;

namespace Monova.Web.Services
{
    public class MVSMonitoring : IMVService
    {

        // Arka planda çalışan bir servis yazıyoruz. Bu servis, request steplerinin hepsini çekip, pendig olanlara işlem yapacak. 
        private Task _task;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

        private MVDContext _db;


        public MVSMonitoring(MVDContext db)
        {
            _db = db;
        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _task = new Task(Monitor, _token, TaskCreationOptions.LongRunning);
            _task.ConfigureAwait(false);
            _task.Start();

        }
        private void Monitor()
        {
            while (true)
            {


            }

        }



        // private MVSMonitoring _instance;
        // public MVSMonitoring Instance
        // {
        //     get
        //     {
        //         lock (_guard)
        //         {
        //             if (_instance == null)
        //                 _instance = new MVSMonitoring();
        //         }

        //         return _instance;
        //     }
        // }
        // public void Init()
        // {
        // }
        // private void Check()
        // {
        //     while (true)
        //     {


        //     }
        // }
    }
}