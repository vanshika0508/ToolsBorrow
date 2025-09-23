using System.Collections.Generic;
using System.Linq;

namespace EquipmentApp.Models
{
    public static class RequestRepository
    {
        private static List<EquipmentRequest> requests = new List<EquipmentRequest>();
        private static int nextId = 1;//initial id  from where the id will gradually increase to make sure two equipments do not have same ID.

        public static IEnumerable<EquipmentRequest> GetAll() => requests;
        

        public static void Add(EquipmentRequest request)
        {
            request.Id = nextId++;//for the increase in the id number when moving from one equipment to other.
            requests.Add(request);
        }

        public static void UpdateStatus(int id, string status)
        {
            var req = requests.FirstOrDefault(r => r.Id == id);
            if (req != null)
            {
                req.Status = status;
            }
        }
    }
}