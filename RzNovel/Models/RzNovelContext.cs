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

        public virtual DbSet<AuthorInfo> AuthorInfos { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookChapter> BookChapters { get; set; }
        public virtual DbSet<BookContent> BookContents { get; set; }
        public virtual DbSet<BookInfo> BookInfos { get; set; }
        public virtual DbSet<HomeBook> HomeBooks { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
