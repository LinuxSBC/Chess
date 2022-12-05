using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess;

public class ChessGame : Game
{
    public static Texture2D chessBoard;

    public ChessPiece BlackRook1;
    public ChessPiece BlackKnight1;
    public ChessPiece BlackBishop1;
    public ChessPiece BlackQueen;
    public ChessPiece BlackKing;
    public ChessPiece BlackBishop2;
    public ChessPiece BlackKnight2;
    public ChessPiece BlackRook2;
    public ChessPiece BlackPawn1;
    public ChessPiece BlackPawn2;
    public ChessPiece BlackPawn3;
    public ChessPiece BlackPawn4;
    public ChessPiece BlackPawn5;
    public ChessPiece BlackPawn6;
    public ChessPiece BlackPawn7;
    public ChessPiece BlackPawn8;
    
    public ChessPiece WhiteRook1;
    public ChessPiece WhiteKnight1;
    public ChessPiece WhiteBishop1;
    public ChessPiece WhiteQueen;
    public ChessPiece WhiteKing;
    public ChessPiece WhiteBishop2;
    public ChessPiece WhiteKnight2;
    public ChessPiece WhiteRook2;
    public ChessPiece WhitePawn1;
    public ChessPiece WhitePawn2;
    public ChessPiece WhitePawn3;
    public ChessPiece WhitePawn4;
    public ChessPiece WhitePawn5;
    public ChessPiece WhitePawn6;
    public ChessPiece WhitePawn7;
    public ChessPiece WhitePawn8;
    
    public List<ChessPiece> BlackPieces;
    public List<ChessPiece> WhitePieces;
    public List<ChessPiece> Pieces;

    public int maxSize;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private ChessPiece _pickedUpPiece;
    private MouseState _mouseState;
    
    public ChessGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        // ChessBoard board = new ChessBoard();
        // board.CreateBoard();
        Window.Title = "Chess";
        Window.AllowUserResizing = true;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        chessBoard = Content.Load<Texture2D>("ChessBoard");

        BlackRook1 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
            new Vector2(0, 0));
        BlackKnight1 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
            new Vector2(1, 0));
        BlackBishop1 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
            new Vector2(2, 0));
        BlackQueen = new(ChessPiece.PieceType.Queen, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackQueen"), 
            new Vector2(3, 0));
        BlackKing = new(ChessPiece.PieceType.King, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKing"), 
            new Vector2(4, 0));
        BlackBishop2 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
            new Vector2(5, 0));
        BlackKnight2 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
            new Vector2(6, 0));
        BlackRook2 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
            new Vector2(7, 0));
        BlackPawn1 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(0, 1));
        BlackPawn2 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(1, 1));
        BlackPawn3 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(2, 1));
        BlackPawn4 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(3, 1));
        BlackPawn5 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(4, 1));
        BlackPawn6 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(5, 1));
        BlackPawn7 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(6, 1));
        BlackPawn8 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(7, 1));
        
        WhiteRook1 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
            new Vector2(0, 7));
        WhiteKnight1 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
            new Vector2(1, 7));
        WhiteBishop1 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
            new Vector2(2, 7));
        WhiteQueen = new(ChessPiece.PieceType.Queen, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteQueen"),
            new Vector2(3, 7));
        WhiteKing = new(ChessPiece.PieceType.King, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKing"),
            new Vector2(4, 7));
        WhiteBishop2 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
            new Vector2(5, 7));
        WhiteKnight2 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
            new Vector2(6, 7));
        WhiteRook2 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
            new Vector2(7, 7));
        WhitePawn1 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(0, 6));
        WhitePawn2 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(1, 6));
        WhitePawn3 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(2, 6));
        WhitePawn4 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(3, 6));
        WhitePawn5 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(4, 6));
        WhitePawn6 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(5, 6));
        WhitePawn7 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(6, 6));
        WhitePawn8 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(7, 6));
        
        BlackPieces = new List<ChessPiece>
        {
            BlackRook1, BlackKnight1, BlackBishop1, BlackQueen, BlackKing, BlackBishop2, BlackKnight2, BlackRook2,
            BlackPawn1, BlackPawn2, BlackPawn3, BlackPawn4, BlackPawn5, BlackPawn6, BlackPawn7, BlackPawn8
        };
        WhitePieces = new List<ChessPiece>
        {
            WhiteRook1, WhiteKnight1, WhiteBishop1, WhiteQueen, WhiteKing, WhiteBishop2, WhiteKnight2, WhiteRook2,
            WhitePawn1, WhitePawn2, WhitePawn3, WhitePawn4, WhitePawn5, WhitePawn6, WhitePawn7, WhitePawn8
        };
        Pieces = Enumerable.Concat(BlackPieces, WhitePieces).ToList();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        var scale = maxSize / 8f;

        _mouseState = Mouse.GetState();
        var mouseClicked = _mouseState.LeftButton == ButtonState.Pressed;
        var mouseSquare = new Vector2((int) (_mouseState.X / scale), (int) (_mouseState.Y / scale));

        if (mouseClicked && _pickedUpPiece == null && 
            _mouseState.X > 0 && _mouseState.X < maxSize && 
            _mouseState.Y > 0 && _mouseState.Y < maxSize &&
            Pieces.Any(p => p.Position == mouseSquare))
        { // Pick up the piece
            _pickedUpPiece = Pieces.FirstOrDefault(p => p.Position == mouseSquare);
            _pickedUpPiece.BeingDragged = true;
        }
        else if (!mouseClicked && _pickedUpPiece != null)
        { // Drop the piece
            if (CanPlace(_pickedUpPiece, mouseSquare))
                _pickedUpPiece.Position = mouseSquare;
            _pickedUpPiece.BeingDragged = false;
            _pickedUpPiece = null;
        }
        
        base.Update(gameTime);
    }
    
    private bool InBounds(Vector2 position)
    {
        return position.X >= 0 && position.X < 8 && position.Y >= 0 && position.Y < 8;
    }
    
    private bool CanPlace(ChessPiece piece, Vector2 position)
    {
        if (!InBounds(position))
            return false;
        if (Pieces.Any(p => p.Position == position))
            return false;
        return true;
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        maxSize = (Window.ClientBounds.Height > Window.ClientBounds.Width) switch
        {
            true => Window.ClientBounds.Width,
            false => Window.ClientBounds.Height
        };
        var scale = maxSize / 8f;
        
        _spriteBatch.Begin(SpriteSortMode.FrontToBack, null);
        _spriteBatch.Draw(chessBoard, 
            new Rectangle(0, 0, maxSize, maxSize), 
            null, 
            Color.White, 
            0f, 
            new Vector2(0, 0), 
            SpriteEffects.None, 
            0f);
        foreach (var piece in Pieces)
        {
            if (!piece.BeingDragged)
                _spriteBatch.Draw(piece.Texture,
                    new Rectangle((int) (piece.Position.X * scale), (int) (piece.Position.Y * scale), (int) scale,
                        (int) scale),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0.1f);
            else
                _spriteBatch.Draw(piece.Texture,
                    new Rectangle(_mouseState.X - (int) scale / 2, _mouseState.Y - (int) scale / 2, 
                        (int) scale, (int) scale),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    1f);
        }

        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}