using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RzNovel.Models
{
    public partial class RzNovelContext : DbContext
    {
        public RzNovelContext()
        {
        }

        public RzNovelContext(DbContextOptions<RzNovelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorCode> AuthorCodes { get; set; }
        public virtual DbSet<AuthorIncome> AuthorIncomes { get; set; }
        public virtual DbSet<AuthorIncomeDetail> AuthorIncomeDetails { get; set; }
        public virtual DbSet<AuthorInfo> AuthorInfos { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookChapter> BookChapters { get; set; }
        public virtual DbSet<BookComment> BookComments { get; set; }
        public virtual DbSet<BookCommentCopy1> BookCommentCopy1s { get; set; }
        public virtual DbSet<BookCommentReply> BookCommentReplies { get; set; }
        public virtual DbSet<BookContent> BookContents { get; set; }
        public virtual DbSet<BookInfo> BookInfos { get; set; }
        public virtual DbSet<HomeBook> HomeBooks { get; set; }
        public virtual DbSet<HomeFriendLink> HomeFriendLinks { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<NewsContent> NewsContents { get; set; }
        public virtual DbSet<NewsInfo> NewsInfos { get; set; }
        public virtual DbSet<PayAlipay> PayAlipays { get; set; }
        public virtual DbSet<PayWechat> PayWechats { get; set; }
        public virtual DbSet<SysLog> SysLogs { get; set; }
        public virtual DbSet<SysMenu> SysMenus { get; set; }
        public virtual DbSet<SysRole> SysRoles { get; set; }
        public virtual DbSet<SysRoleMenu> SysRoleMenus { get; set; }
        public virtual DbSet<SysUser> SysUsers { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<UserBookshelf> UserBookshelves { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
        public virtual DbSet<UserCommentReply> UserCommentReplies { get; set; }
        public virtual DbSet<UserConsumeLog> UserConsumeLogs { get; set; }
        public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserPayLog> UserPayLogs { get; set; }
        public virtual DbSet<UserReadHistory> UserReadHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-KJQFCD7V;Initial Catalog=RzNovel;User ID=SA;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuthorCode>(entity =>
            {
                entity.ToTable("author_code");

                entity.HasIndex(e => e.InviteCode, "author_code$idx_code")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "author_code$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.InviteCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("invite_code");

                entity.Property(e => e.IsUsed).HasColumnName("is_used");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.ValidityTime)
                    .HasPrecision(0)
                    .HasColumnName("validity_time");
            });

            modelBuilder.Entity<AuthorIncome>(entity =>
            {
                entity.ToTable("author_income");

                entity.HasIndex(e => e.Id, "author_income$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AfterTaxIncome).HasColumnName("after_tax_income");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.ConfirmStatus).HasColumnName("confirm_status");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Detail)
                    .HasMaxLength(255)
                    .HasColumnName("detail");

                entity.Property(e => e.IncomeMonth)
                    .HasColumnType("date")
                    .HasColumnName("income_month");

                entity.Property(e => e.PayStatus).HasColumnName("pay_status");

                entity.Property(e => e.PreTaxIncome).HasColumnName("pre_tax_income");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<AuthorIncomeDetail>(entity =>
            {
                entity.ToTable("author_income_detail");

                entity.HasIndex(e => e.Id, "author_income_detail$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.IncomeAccount).HasColumnName("income_account");

                entity.Property(e => e.IncomeCount).HasColumnName("income_count");

                entity.Property(e => e.IncomeDate)
                    .HasColumnType("date")
                    .HasColumnName("income_date");

                entity.Property(e => e.IncomeNumber).HasColumnName("income_number");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<AuthorInfo>(entity =>
            {
                entity.ToTable("author_info");

                entity.HasIndex(e => e.Id, "author_info$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "author_info$uk_userId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChatAccount)
                    .HasMaxLength(50)
                    .HasColumnName("chat_account");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.InviteCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("invite_code");

                entity.Property(e => e.PenName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pen_name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TelPhone)
                    .HasMaxLength(20)
                    .HasColumnName("tel_phone");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WorkDirection).HasColumnName("work_direction");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.ToTable("book_category");

                entity.HasIndex(e => e.Id, "book_category$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.WorkDirection).HasColumnName("work_direction");
            });

            modelBuilder.Entity<BookChapter>(entity =>
            {
                entity.ToTable("book_chapter");

                entity.HasIndex(e => e.Id, "book_chapter$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.BookId, e.ChapterNum }, "book_chapter$uk_bookId_chapterNum")
                    .IsUnique();

                entity.HasIndex(e => e.BookId, "idx_bookId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.ChapterName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("chapter_name");

                entity.Property(e => e.ChapterNum).HasColumnName("chapter_num");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.IsVip).HasColumnName("is_vip");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.WordCount).HasColumnName("word_count");
            });

            modelBuilder.Entity<BookComment>(entity =>
            {
                entity.ToTable("book_comment");

                entity.HasIndex(e => e.Id, "book_comment$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.BookId, e.UserId }, "book_comment$uk_bookId_userId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuditStatus).HasColumnName("audit_status");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("comment_content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ReplyCount).HasColumnName("reply_count");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BookCommentCopy1>(entity =>
            {
                entity.ToTable("book_comment_copy1");

                entity.HasIndex(e => e.Id, "book_comment_copy1$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.BookId, e.UserId }, "book_comment_copy1$uk_bookId_userId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuditStatus).HasColumnName("audit_status");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("comment_content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ReplyCount).HasColumnName("reply_count");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BookCommentReply>(entity =>
            {
                entity.ToTable("book_comment_reply");

                entity.HasIndex(e => e.Id, "book_comment_reply$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AuditStatus).HasColumnName("audit_status");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("reply_content");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BookContent>(entity =>
            {
                entity.ToTable("book_content");

                entity.HasIndex(e => e.Id, "book_content$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.ChapterId, "book_content$uk_chapterId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChapterId).HasColumnName("chapter_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<BookInfo>(entity =>
            {
                entity.ToTable("book_info");

                entity.HasIndex(e => e.Id, "book_info$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.BookName, e.AuthorName }, "book_info$uk_bookName_authorName")
                    .IsUnique();

                entity.HasIndex(e => e.CreateTime, "idx_createTime");

                entity.HasIndex(e => e.LastChapterUpdateTime, "idx_lastChapterUpdateTime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author_name");

                entity.Property(e => e.BookDesc)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("book_desc");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("book_name");

                entity.Property(e => e.BookStatus).HasColumnName("book_status");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");

                entity.Property(e => e.CommentCount).HasColumnName("comment_count");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.IsVip).HasColumnName("is_vip");

                entity.Property(e => e.LastChapterId).HasColumnName("last_chapter_id");

                entity.Property(e => e.LastChapterName)
                    .HasMaxLength(50)
                    .HasColumnName("last_chapter_name");

                entity.Property(e => e.LastChapterUpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("last_chapter_update_time");

                entity.Property(e => e.PicUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pic_url");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.VisitCount)
                    .HasColumnName("visit_count")
                    .HasDefaultValueSql("((103))");

                entity.Property(e => e.WordCount).HasColumnName("word_count");

                entity.Property(e => e.WorkDirection).HasColumnName("work_direction");
            });

            modelBuilder.Entity<HomeBook>(entity =>
            {
                entity.ToTable("home_book");

                entity.HasIndex(e => e.Id, "home_book$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<HomeFriendLink>(entity =>
            {
                entity.ToTable("home_friend_link");

                entity.HasIndex(e => e.Id, "home_friend_link$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.IsOpen)
                    .HasColumnName("is_open")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("link_name");

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("link_url");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((11))");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.ToTable("news_category");

                entity.HasIndex(e => e.Id, "news_category$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<NewsContent>(entity =>
            {
                entity.ToTable("news_content");

                entity.HasIndex(e => e.Id, "news_content$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.NewsId, "news_content$uk_newsId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<NewsInfo>(entity =>
            {
                entity.ToTable("news_info");

                entity.HasIndex(e => e.Id, "news_info$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("category_name");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.SourceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("source_name");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<PayAlipay>(entity =>
            {
                entity.ToTable("pay_alipay");

                entity.HasIndex(e => e.Id, "pay_alipay$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.OutTradeNo, "uk_outTradeNo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuyerId)
                    .HasMaxLength(16)
                    .HasColumnName("buyer_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.GmtCreate)
                    .HasPrecision(0)
                    .HasColumnName("gmt_create");

                entity.Property(e => e.GmtPayment)
                    .HasPrecision(0)
                    .HasColumnName("gmt_payment");

                entity.Property(e => e.InvoiceAmount).HasColumnName("invoice_amount");

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("out_trade_no");

                entity.Property(e => e.ReceiptAmount).HasColumnName("receipt_amount");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.TradeNo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trade_no");

                entity.Property(e => e.TradeStatus)
                    .HasMaxLength(32)
                    .HasColumnName("trade_status");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<PayWechat>(entity =>
            {
                entity.ToTable("pay_wechat");

                entity.HasIndex(e => e.Id, "pay_wechat$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.OutTradeNo, "uk_outTradeNo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("out_trade_no");

                entity.Property(e => e.PayerOpenid)
                    .HasMaxLength(128)
                    .HasColumnName("payer_openid");

                entity.Property(e => e.PayerTotal).HasColumnName("payer_total");

                entity.Property(e => e.SuccessTime)
                    .HasPrecision(0)
                    .HasColumnName("success_time");

                entity.Property(e => e.TradeState)
                    .HasMaxLength(32)
                    .HasColumnName("trade_state");

                entity.Property(e => e.TradeStateDesc)
                    .HasMaxLength(255)
                    .HasColumnName("trade_state_desc");

                entity.Property(e => e.TradeType)
                    .HasMaxLength(16)
                    .HasColumnName("trade_type");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.ToTable("sys_log");

                entity.HasIndex(e => e.Id, "sys_log$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Ip)
                    .HasMaxLength(64)
                    .HasColumnName("ip");

                entity.Property(e => e.Method)
                    .HasMaxLength(200)
                    .HasColumnName("method");

                entity.Property(e => e.Operation)
                    .HasMaxLength(50)
                    .HasColumnName("operation");

                entity.Property(e => e.Params).HasColumnName("params");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("sys_menu");

                entity.HasIndex(e => e.Id, "sys_menu$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .HasColumnName("icon");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("sys_role");

                entity.HasIndex(e => e.Id, "sys_role$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleSign)
                    .HasMaxLength(100)
                    .HasColumnName("role_sign");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<SysRoleMenu>(entity =>
            {
                entity.ToTable("sys_role_menu");

                entity.HasIndex(e => e.Id, "sys_role_menu$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user");

                entity.HasIndex(e => e.Id, "sys_user$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birth)
                    .HasPrecision(0)
                    .HasColumnName("birth");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(100)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.ToTable("sys_user_role");

                entity.HasIndex(e => e.Id, "sys_user_role$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Test1).HasColumnName("test");

                entity.Property(e => e.Test2).HasColumnName("test2");
            });

            modelBuilder.Entity<UserBookshelf>(entity =>
            {
                entity.ToTable("user_bookshelf");

                entity.HasIndex(e => e.Id, "user_bookshelf$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.BookId }, "user_bookshelf$uk_userId_bookId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.PreContentId).HasColumnName("pre_content_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.ToTable("user_comment");

                entity.HasIndex(e => e.Id, "user_comment$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.BookId, e.UserId }, "user_comment$uk_bookId_userId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuditStatus).HasColumnName("audit_status");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("comment_content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ReplyCount).HasColumnName("reply_count");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserCommentReply>(entity =>
            {
                entity.ToTable("user_comment_reply");

                entity.HasIndex(e => e.Id, "user_comment_reply$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AuditStatus).HasColumnName("audit_status");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("reply_content");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserConsumeLog>(entity =>
            {
                entity.ToTable("user_consume_log");

                entity.HasIndex(e => e.Id, "user_consume_log$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.ProducName)
                    .HasMaxLength(50)
                    .HasColumnName("produc_name");

                entity.Property(e => e.ProducValue).HasColumnName("produc_value");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductType).HasColumnName("product_type");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserFeedback>(entity =>
            {
                entity.ToTable("user_feedback");

                entity.HasIndex(e => e.Id, "user_feedback$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("content");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("user_info");

                entity.HasIndex(e => e.Id, "user_info$pk_id")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "user_info$uk_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountBalance).HasColumnName("account_balance");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .HasColumnName("nick_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("salt");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserPhoto)
                    .HasMaxLength(100)
                    .HasColumnName("user_photo");

                entity.Property(e => e.UserSex).HasColumnName("user_sex");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserPayLog>(entity =>
            {
                entity.ToTable("user_pay_log");

                entity.HasIndex(e => e.Id, "user_pay_log$pk_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("out_trade_no");

                entity.Property(e => e.PayChannel)
                    .HasColumnName("pay_channel")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PayTime)
                    .HasPrecision(0)
                    .HasColumnName("pay_time");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductType).HasColumnName("product_type");

                entity.Property(e => e.ProductValue).HasColumnName("product_value");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserReadHistory>(entity =>
            {
                entity.ToTable("user_read_history");

                entity.HasIndex(e => e.Id, "user_read_history$pk_id")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.BookId }, "user_read_history$uk_userId_bookId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.CreateTime)
                    .HasPrecision(0)
                    .HasColumnName("create_time");

                entity.Property(e => e.PreContentId).HasColumnName("pre_content_id");

                entity.Property(e => e.UpdateTime)
                    .HasPrecision(0)
                    .HasColumnName("update_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
