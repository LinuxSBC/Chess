using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess;

public class ChessGame : Game
{
    private static Texture2D _chessBoard;

    private ChessPiece _blackRook1;
    private ChessPiece _blackKnight1;
    private ChessPiece _blackBishop1;
    private ChessPiece _blackQueen;
    private ChessPiece _blackKing;
    private ChessPiece _blackBishop2;
    private ChessPiece _blackKnight2;
    private ChessPiece _blackRook2;
    private ChessPiece _blackPawn1;
    private ChessPiece _blackPawn2;
    private ChessPiece _blackPawn3;
    private ChessPiece _blackPawn4;
    private ChessPiece _blackPawn5;
    private ChessPiece _blackPawn6;
    private ChessPiece _blackPawn7;
    private ChessPiece _blackPawn8;
    
    private ChessPiece _whiteRook1;
    private ChessPiece _whiteKnight1;
    private ChessPiece _whiteBishop1;
    private ChessPiece _whiteQueen;
    private ChessPiece _whiteKing;
    private ChessPiece _whiteBishop2;
    private ChessPiece _whiteKnight2;
    private ChessPiece _whiteRook2;
    private ChessPiece _whitePawn1;
    private ChessPiece _whitePawn2;
    private ChessPiece _whitePawn3;
    private ChessPiece _whitePawn4;
    private ChessPiece _whitePawn5;
    private ChessPiece _whitePawn6;
    private ChessPiece _whitePawn7;
    private ChessPiece _whitePawn8;
    
    private List<ChessPiece> _blackPieces;
    private List<ChessPiece> _whitePieces;
    private List<ChessPiece> _pieces;

    private int _maxSize;

    // ReSharper disable once NotAccessedField.Local
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
        Window.Title = "Chess";
        Window.AllowUserResizing = true;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _chessBoard = Content.Load<Texture2D>("ChessBoard");

        _blackRook1 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
            new Vector2(0, 0));
        _blackKnight1 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
            new Vector2(1, 0));
        _blackBishop1 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
            new Vector2(2, 0));
        _blackQueen = new(ChessPiece.PieceType.Queen, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackQueen"), 
            new Vector2(3, 0));
        _blackKing = new(ChessPiece.PieceType.King, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKing"), 
            new Vector2(4, 0));
        _blackBishop2 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
            new Vector2(5, 0));
        _blackKnight2 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
            new Vector2(6, 0));
        _blackRook2 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
            new Vector2(7, 0));
        _blackPawn1 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(0, 1));
        _blackPawn2 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(1, 1));
        _blackPawn3 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(2, 1));
        _blackPawn4 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(3, 1));
        _blackPawn5 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(4, 1));
        _blackPawn6 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(5, 1));
        _blackPawn7 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(6, 1));
        _blackPawn8 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.Black, Content.Load<Texture2D>("BlackPawn"), 
            new Vector2(7, 1));
        
        _whiteRook1 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
            new Vector2(0, 7));
        _whiteKnight1 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
            new Vector2(1, 7));
        _whiteBishop1 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
            new Vector2(2, 7));
        _whiteQueen = new(ChessPiece.PieceType.Queen, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteQueen"),
            new Vector2(3, 7));
        _whiteKing = new(ChessPiece.PieceType.King, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKing"),
            new Vector2(4, 7));
        _whiteBishop2 = new(ChessPiece.PieceType.Bishop, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
            new Vector2(5, 7));
        _whiteKnight2 = new(ChessPiece.PieceType.Knight, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
            new Vector2(6, 7));
        _whiteRook2 = new(ChessPiece.PieceType.Rook, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
            new Vector2(7, 7));
        _whitePawn1 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(0, 6));
        _whitePawn2 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(1, 6));
        _whitePawn3 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(2, 6));
        _whitePawn4 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(3, 6));
        _whitePawn5 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(4, 6));
        _whitePawn6 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(5, 6));
        _whitePawn7 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(6, 6));
        _whitePawn8 = new(ChessPiece.PieceType.Pawn, ChessPiece.PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
            new Vector2(7, 6));
        
        _blackPieces = new List<ChessPiece>
        {
            _blackRook1, _blackKnight1, _blackBishop1, _blackQueen, _blackKing, _blackBishop2, _blackKnight2, _blackRook2,
            _blackPawn1, _blackPawn2, _blackPawn3, _blackPawn4, _blackPawn5, _blackPawn6, _blackPawn7, _blackPawn8
        };
        _whitePieces = new List<ChessPiece>
        {
            _whiteRook1, _whiteKnight1, _whiteBishop1, _whiteQueen, _whiteKing, _whiteBishop2, _whiteKnight2, _whiteRook2,
            _whitePawn1, _whitePawn2, _whitePawn3, _whitePawn4, _whitePawn5, _whitePawn6, _whitePawn7, _whitePawn8
        };
        _pieces = Enumerable.Concat(_blackPieces, _whitePieces).ToList();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _mouseState = Mouse.GetState();
        var mouseClicked = _mouseState.LeftButton == ButtonState.Pressed;
        var mouseSquare = ToChessGrid(_mouseState.X, _mouseState.Y);

        if (mouseClicked && _pickedUpPiece == null && 
            _mouseState.X > 0 && _mouseState.X < _maxSize && 
            _mouseState.Y > 0 && _mouseState.Y < _maxSize &&
            _pieces.Any(p => p.Position == mouseSquare))
        {
            // Pick up the piece
            _pickedUpPiece = _pieces.FirstOrDefault(p => p.Position == mouseSquare);
            if (_pickedUpPiece != null) _pickedUpPiece.BeingDragged = true;
        }
        else if (!mouseClicked && _pickedUpPiece != null)
        { // Drop the piece
            Place(_pickedUpPiece, mouseSquare);

            _pickedUpPiece.BeingDragged = false;
            _pickedUpPiece = null;
        }
        
        base.Update(gameTime);
    }
    
    private Vector2 ToChessGrid(Vector2 position)
    {
        var scale = _maxSize / 8f;
        return new Vector2((int) (position.X / scale), (int) (position.Y / scale));
    }
        
    private Vector2 ToScreenSpace(Vector2 position)
    {
        var scale = _maxSize / 8f;
        return new Vector2(position.X * scale, position.Y * scale);
    }
    
    private float ToChessGrid(float position)
    {
        return ToChessGrid(new Vector2(position, 0)).X;
    }
    
    private Vector2 ToChessGrid(float x, float y)
    {
        return ToChessGrid(new Vector2(x, y));
    }

    private float ToScreenSpace(float position)
    {
        return ToScreenSpace(new Vector2(position, 0)).X;
    }
    
    private Vector2 ToScreenSpace(float x, float y)
    {
        return ToScreenSpace(new Vector2(x, y));
    }
    
    private void Place(ChessPiece piece, Vector2 position)
    {
        if (!CanPlace(piece, position)) return;
        if (!Capture(piece, position)) return;

        piece.Position = position;

        if (!piece.HasMoved)
            piece.HasMoved = true;

        if (piece.Type == ChessPiece.PieceType.Pawn && (position.Y == 0 || (int) position.Y == 7))
        { // TODO: Add choice for promotion
            piece.Type = ChessPiece.PieceType.Queen;
            piece.Texture = piece.Color == ChessPiece.PieceColor.Black
                ? Content.Load<Texture2D>("BlackQueen")
                : Content.Load<Texture2D>("WhiteQueen");
        }
    }

    private bool Capture(ChessPiece piece, Vector2 position)
    {
        if (!CanPlace(piece, position)) return false;
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == position);
        if (pieceToTake != null && pieceToTake.Color != piece.Color)
        {
            if (pieceToTake.Color == ChessPiece.PieceColor.Black)
                _blackPieces.Remove(pieceToTake);
            else
                _whitePieces.Remove(pieceToTake);

            _pieces.Remove(pieceToTake);
        }

        return true;
    }
    
    private bool InBounds(Vector2 position)
    {
        return position.X >= 0 && position.X < 8 && position.Y >= 0 && position.Y < 8;
    }
    
    private bool CanPlace(ChessPiece piece, Vector2 position)
    {
        if (!InBounds(position))
            return false;
        if (_pieces.Any(p => p.Position == position && p.Color == piece.Color))
            return false;
        if (!piece.CanMoveTo(position))
            return false;
        if (piece.Type == ChessPiece.PieceType.Pawn)
            if (!(Math.Abs((int) position.X - (int) piece.Position.X) == 1 &&
                Math.Abs((int) position.Y - (int) piece.Position.Y) == 1) && 
                _pieces.Any(p => p.Position == position))
                return false;
        return true;
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _maxSize = (Window.ClientBounds.Height > Window.ClientBounds.Width) switch
        {
            true => Window.ClientBounds.Width,
            false => Window.ClientBounds.Height
        };
        
        _spriteBatch.Begin(SpriteSortMode.FrontToBack);
        _spriteBatch.Draw(_chessBoard, 
            new Rectangle(0, 0, _maxSize, _maxSize), 
            null, 
            Color.White, 
            0f, 
            new Vector2(0, 0), 
            SpriteEffects.None, 
            0f);
        foreach (var piece in _pieces)
        {
            if (!piece.BeingDragged)
                _spriteBatch.Draw(piece.Texture,
                    new Rectangle((int) ToScreenSpace(piece.Position.X), 
                        (int) ToScreenSpace(piece.Position.Y), 
                        (int) ToScreenSpace(1), (int) ToScreenSpace(1)),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0.1f);
            else
                _spriteBatch.Draw(piece.Texture,
                    new Rectangle(_mouseState.X - (int) ToScreenSpace(0.5f), 
                        _mouseState.Y - (int) ToScreenSpace(0.5f), 
                        (int) ToScreenSpace(1), (int) ToScreenSpace(1)),
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