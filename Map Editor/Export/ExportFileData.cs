namespace MapEditor.Export {
    public sealed class ExportFileData {
        /// <summary>
        /// Id da textura.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Posição da textura dentro do arquivo de mapa.
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public byte[] Data { get; set; }
    }
}