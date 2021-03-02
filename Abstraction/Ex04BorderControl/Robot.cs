using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04BorderControl
{
    public class Robot : IIdentity
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
        public string Id { get => this.id; set => this.id=value; }
    }
}
