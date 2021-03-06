﻿using System.Linq;
using CoralTime.Common.Constants;
using CoralTime.DAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CoralTime.DAL.Repositories
{
    public class ProjectRoleRepository : _BaseRepository<ProjectRole>
    {
        public ProjectRoleRepository(AppDbContext context, IMemoryCache memoryCache, string userId) 
            : base(context, memoryCache, userId) { }

        public int GetManagerRoleId()
        {
            return LinkedCacheGetList().FirstOrDefault(z => z.Name == Constants.ManagerRole).Id;
        }

        public int GetMemberRoleId()
        {
            return LinkedCacheGetList().FirstOrDefault(z => z.Name == Constants.MemberRole).Id;
        }

        public ProjectRole GetMemberRole()
        {
            var memberRole = LinkedCacheGetList().FirstOrDefault(z => z.Name == Constants.MemberRole);
            return memberRole;
        }
    }
}