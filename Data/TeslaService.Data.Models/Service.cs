namespace TeslaService.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Service
    {
        public Service()
        {
            this.Employees = new HashSet<Employee>();
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public int VehicleId { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
