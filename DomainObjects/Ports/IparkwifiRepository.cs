using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace parkWiFis.DomainObjects.Ports
{
    public interface IReadOnlyparkwifiRepository
    {
        Task<parkWiFi> GetparkWiFi(long id);

        Task<IEnumerable<parkWiFi>> GetAllparkWiFis();

        Task<IEnumerable<parkWiFi>> QueryparkWiFis(ICriteria<parkWiFi> criteria);

    }

    public interface IparkwifiRepository
    {
        Task AddparkWiFi(parkWiFi parkwifi);

        Task RemoveparkWiFi(parkWiFi parkwifi);

        Task UpdateparkWiFi(parkWiFi parkwifi);
    }
}
