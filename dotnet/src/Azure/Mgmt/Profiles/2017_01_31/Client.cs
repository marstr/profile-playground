using _2016_01_31 = Azure.Mgmt.Compute._2016_01_31;
using _2016_06_30 = Azure.Mgmt.Compute._2016_06_30;

namespace Azure.Mgmt.Profiles._2017_01_31
{
    namespace Models {
        public class Factories
        {
            public _2016_01_31.Models.VirtualMachine VirtualMachine(_2016_01_31.Models.Plan plan = default(_2016_01_31.Models.Plan), string licenseType = default(string))
            {
                return new _2016_01_31.Models.VirtualMachine
                {
                    Plan = plan,
                    LicenseType = licenseType
                };
            }

            public _2016_01_31.Models.Plan Plan(string name = default(string), string publisher = default(string), string promotionCode = default(string))
            {
                return new _2016_01_31.Models.Plan
                {
                    Name = name,
                    Publisher = publisher,
                    PromotionCode = promotionCode
                };
            }

            public _2016_06_30.Models.Disk Disk(int? diskSizeGB = default(int?), string ownerId = default(string))
            {
                return new _2016_06_30.Models.Disk
                {
                    DiskSizeGB = diskSizeGB,
                    OwnerId = ownerId
                };
            }
        }
    }
    public class Compute
    {
        internal Compute(AzureClient client)
        {
            VirtualMachines = new _2016_01_31.Operations.VirtualMachinesOperations(client);
            Disks = new _2016_06_30.Operations.DisksOperations(client);
            Models = new Models.Factories();
        }
        public _2016_01_31.Operations.VirtualMachinesOperations VirtualMachines { get; protected set; }
        public _2016_06_30.Operations.DisksOperations Disks { get; protected set; }

        public Models.Factories Models { get; protected set; }

    }

    public class Client : AzureClient
    {
        public Client()
        {
            Compute = new Compute(this);
        }

        public Compute Compute { get; protected set; }
    }
}