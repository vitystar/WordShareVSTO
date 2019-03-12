using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class WordDBContext:DbContext
    {
        /// <summary>
        /// 继承构造函数
        /// </summary>
        public WordDBContext() : base("name=DBConnStr") { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// 实体库
        /// </summary>
        public DbSet<WordTemplet> WordTemplet { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<OrganizationInfo> OrganizationInfo { get; set; }
        public DbSet<ImageTemplet> ImageTemplet { get; set; }
        public DbSet<AudioTemplet> AudioTemplet { get; set; }
        public DbSet<VideoTemplet> VideoTemplet { get; set; }
        public DbSet<ExcelTemplet> ExcelTemplet { get; set; }
        public DbSet<PPTTemplet> PPTTemplet { get; set; }
    }
}
