using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.logistics_db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:attachment_type", "invoice,payment_proof,package_photo,delivery_evidence,other")
                .Annotation("Npgsql:Enum:customer_type", "individual,online_store,courier,entrepreneur")
                .Annotation("Npgsql:Enum:package_status", "registered,warehouse,shipped,customs,agency,available_pickup,out_for_delivery,delivered,incident,retained,pending_payment")
                .Annotation("Npgsql:Enum:package_type", "standard,fragile")
                .Annotation("Npgsql:Enum:payment_method", "bank_transfer,card,credit")
                .Annotation("Npgsql:Enum:payment_status", "pending,validated,rejected");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    app_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerType = table.Column<int>(type: "integer", nullable: false),
                    document_id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    business_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    whatsapp = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customs_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    max_declared_value = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    max_weight_kg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    max_weight_lb = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, defaultValueSql: "'USD'::character varying"),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("customs_category_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "locker",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    us_address_line = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false, defaultValueSql: "'Hialeah'::character varying"),
                    state = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false, defaultValueSql: "'FL'::character varying"),
                    country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false, defaultValueSql: "'USA'::character varying"),
                    zip_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("locker_pkey", x => x.id);
                    table.ForeignKey(
                        name: "locker_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    package_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    file_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    original_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    mime_type = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    size_bytes = table.Column<long>(type: "bigint", nullable: true),
                    uploaded_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachment_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "declared_purchase",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    external_tracking = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    product_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    declared_value = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, defaultValueSql: "'USD'::character varying"),
                    estimated_weight_lb = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    customs_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invoice_attachment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("declared_purchase_pkey", x => x.id);
                    table.ForeignKey(
                        name: "declared_purchase_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "declared_purchase_customs_category_id_fkey",
                        column: x => x.customs_category_id,
                        principalTable: "customs_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "declared_purchase_invoice_attachment_id_fkey",
                        column: x => x.invoice_attachment_id,
                        principalTable: "attachment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, defaultValueSql: "'USD'::character varying"),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    proof_attachment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    reject_reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    validated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    validated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("payment_pkey", x => x.id);
                    table.ForeignKey(
                        name: "payment_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "payment_proof_attachment_id_fkey",
                        column: x => x.proof_attachment_id,
                        principalTable: "attachment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    warehouse_number = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    external_tracking = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    locker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customs_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    declared_purchase_id = table.Column<Guid>(type: "uuid", nullable: false),
                    PackageType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    weight_lb = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    weight_kg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    pieces = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    is_repacked = table.Column<bool>(type: "boolean", nullable: false),
                    declared_value = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false, defaultValueSql: "'USD'::character varying"),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_fragile = table.Column<bool>(type: "boolean", nullable: false),
                    observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    received_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("package_pkey", x => x.id);
                    table.ForeignKey(
                        name: "package_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "package_customs_category_id_fkey",
                        column: x => x.customs_category_id,
                        principalTable: "customs_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "package_declared_purchase_id_fkey",
                        column: x => x.declared_purchase_id,
                        principalTable: "declared_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "package_locker_id_fkey",
                        column: x => x.locker_id,
                        principalTable: "locker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tracking_event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    package_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_visible_to_customer = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp(6) with time zone", precision: 6, nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("tracking_event_pkey", x => x.id);
                    table.ForeignKey(
                        name: "tracking_event_package_id_fkey",
                        column: x => x.package_id,
                        principalTable: "package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_attachment_package",
                table: "attachment",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "customer_app_user_id_key",
                table: "customer",
                column: "app_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_customer_app_user",
                table: "customer",
                column: "app_user_id");

            migrationBuilder.CreateIndex(
                name: "customs_category_code_key",
                table: "customs_category",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_declared_purchase_customer",
                table: "declared_purchase",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_declared_purchase_customs_category_id",
                table: "declared_purchase",
                column: "customs_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_declared_purchase_invoice_attachment_id",
                table: "declared_purchase",
                column: "invoice_attachment_id");

            migrationBuilder.CreateIndex(
                name: "locker_code_key",
                table: "locker",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "locker_customer_id_key",
                table: "locker",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_package_customer",
                table: "package",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "idx_package_external_tracking",
                table: "package",
                column: "external_tracking");

            migrationBuilder.CreateIndex(
                name: "idx_package_warehouse_number",
                table: "package",
                column: "warehouse_number");

            migrationBuilder.CreateIndex(
                name: "IX_package_customs_category_id",
                table: "package",
                column: "customs_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_package_declared_purchase_id",
                table: "package",
                column: "declared_purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_package_locker_id",
                table: "package",
                column: "locker_id");

            migrationBuilder.CreateIndex(
                name: "package_warehouse_number_key",
                table: "package",
                column: "warehouse_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_payment_customer",
                table: "payment",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_proof_attachment_id",
                table: "payment",
                column: "proof_attachment_id");

            migrationBuilder.CreateIndex(
                name: "payment_code_key",
                table: "payment",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_tracking_event_created",
                table: "tracking_event",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "idx_tracking_event_package",
                table: "tracking_event",
                column: "package_id");

            migrationBuilder.AddForeignKey(
                name: "attachment_package_id_fkey",
                table: "attachment",
                column: "package_id",
                principalTable: "package",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "attachment_package_id_fkey",
                table: "attachment");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "tracking_event");

            migrationBuilder.DropTable(
                name: "package");

            migrationBuilder.DropTable(
                name: "declared_purchase");

            migrationBuilder.DropTable(
                name: "locker");

            migrationBuilder.DropTable(
                name: "customs_category");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
