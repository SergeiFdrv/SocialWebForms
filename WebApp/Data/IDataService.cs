using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApp.Data
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IDataService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        void DoWork();
    }
}
