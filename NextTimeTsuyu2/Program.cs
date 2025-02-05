

using NextTimeTsuyu2;

string read_path = "C:\\CD\\TEST\\NestTImeTsuyu\\WriteStructure2";

string write_path = "C:\\CD\\TEST\\NestTImeTsuyu\\Testing";

int current_core_count = Environment.ProcessorCount;
Setting setting = new Setting(1024 * 1024, current_core_count, long.MaxValue, LoadBalancer.TYPE.BASIC);
Backup backup = Backup.h_backup_start(read_path, write_path, setting);

Console.WriteLine(backup.get_memory_cluster.get_total_byte_size);
Console.WriteLine(backup.get_memory_cluster.get_use_byte_size);
Console.WriteLine(backup.get_memory_cluster.get_worked_byte_size);