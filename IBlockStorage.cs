public interface IBlockStorage
{
    /// <summary>
    /// Number of bytes of custom data per block that this storage can handle.
    /// </summary>
    int BlockContentSize {
        get;
    }

    /// <summary>
    /// Total number of bytes in header
    /// </summary>
    int BlockHeaderSize {
        get;
    }

    /// <summary>
    /// Total block size, equal to content size + header size, should be a multiple of 128B
    /// </summary>
    int BlockSize {
        get;
    }

    /// <summary>
    /// Find a block by its id
    /// </summary>
    IBlock Find (uint blockId);

    /// <summary>
    /// Allocate new block, extend the length of underlying storage
    /// </summary>
    IBlock CreateNew ();
}

public interface IBlock : IDisposable
{
    /// <summary>
    /// Id of the block, must be unique
    /// </summary>
    uint Id {
        get;
    }

    /// <summary>
    /// A block may contain one ore more header metadata,
    /// each header identified by a number and 8 bytes value.
    /// </summary>
    long GetHeader (int field);

    /// <summary>
    /// Change the value of specified header.
    /// Data must not be written to disk until the block is disposed.
    /// </summary>
    void SetHeader (int field, long value);

    /// <summary>
    /// Read content of this block (src) into given buffer (dst)
    /// </summary>
    void Read (byte[] dst, int dstOffset, int srcOffset, int count);

    /// <summary>
    /// Write content of given buffer (src) into this (dst)
    /// </summary>
    void Write (byte[] src, int srcOffset, int dstOffset, int count);
}