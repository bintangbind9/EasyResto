﻿namespace EasyResto.Domain.Contracts.Response
{
    public class RoleResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<PrivilegeResponse> Privileges { get; set; } = new List<PrivilegeResponse>();
    }
}
