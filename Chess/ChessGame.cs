using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess;

public class ChessGame : Game
{
    private const int LeftSide = 0;
    private const int RightSide = 7;
    private const int TopSide = 0;
    private const int BottomSide = 7;

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

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private ChessPiece _pickedUpPiece;
    private MouseState _mouseState;

    private ChessPiece.PieceColor _turn;
    
    public ChessGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _turn = ChessPiece.PieceColor.White; // White starts
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
        _pieces = _blackPieces.Concat(_whitePieces).ToList();
    }

    protected override void Update(GameTime gameTime)
    {
        bool backButtonPressed = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
        bool escapeKeyPressed = Keyboard.GetState().IsKeyDown(Keys.Escape);
        _mouseState = Mouse.GetState();
        var mouseClicked = _mouseState.LeftButton == ButtonState.Pressed;
        var mouseSquare = ToChessGrid(_mouseState.X, _mouseState.Y);
        bool holdingPiece = _pickedUpPiece != null;
        bool mouseInBoardX = _mouseState.X > 0 && _mouseState.X < _maxSize;
        bool mouseInBoardY = _mouseState.Y > 0 && _mouseState.Y < _maxSize;
        bool mouseInBoard = mouseInBoardX && mouseInBoardY;
        bool isPieceUnderMouse = _pieces.Any(p => p.Position == mouseSquare);

        if (backButtonPressed || escapeKeyPressed)
            Exit();
        
        if (mouseClicked && !holdingPiece && mouseInBoard && isPieceUnderMouse)
            PickUpPiece(mouseSquare);
        else if (!mouseClicked && holdingPiece)
            PlacePiece(mouseSquare);

        base.Update(gameTime);
    }

    private void PlacePiece(Vector2 mouseSquare)
    {
        Place(_pickedUpPiece, mouseSquare);

        _pickedUpPiece.BeingDragged = false;
        _pickedUpPiece = null;
    }

    private void PickUpPiece(Vector2 mouseSquare)
    {
        _pickedUpPiece = _pieces.FirstOrDefault(p => p.Position == mouseSquare);
        if (_pickedUpPiece != null) _pickedUpPiece.BeingDragged = true;
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
    
    private void Place(ChessPiece piece, Vector2 target, bool changeTurn = true)
    {
        bool wrongTurn = changeTurn && piece.Color != _turn;
        
        if (!CanMove(piece, target) || wrongTurn) return;
        
        if (CanCastle(piece, target)) Castle(piece, target);
        
        if (CanCapture(piece, target)) Capture(piece, target);
        
        piece.Position = target;

        if (!piece.HasMoved)
            piece.HasMoved = true;

        if (changeTurn)
            _turn = _turn == ChessPiece.PieceColor.White ? ChessPiece.PieceColor.Black : ChessPiece.PieceColor.White;

        if (piece.Type == ChessPiece.PieceType.Pawn && (target.Y == 0 || (int) target.Y == 7))
        { // TODO: Add choice for promotion
            piece.Type = ChessPiece.PieceType.Queen;
            piece.Texture = piece.Color == ChessPiece.PieceColor.Black
                ? Content.Load<Texture2D>("BlackQueen")
                : Content.Load<Texture2D>("WhiteQueen");
        }
        
        // TODO: Add checkmate dialog
    }

    private void Capture(ChessPiece piece, Vector2 target)
    {
        if (!CanCapture(piece, target) || InCheckAfterMove(piece, target)) return;
        
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        if (pieceToTake is {Color: ChessPiece.PieceColor.Black})
            _blackPieces.Remove(pieceToTake);
        else
            _whitePieces.Remove(pieceToTake);

        _pieces.Remove(pieceToTake);
    }

    private bool InCheckAfterMove(ChessPiece piece, Vector2 target)
    {
        ChessPiece pieceToTake = null;
        var captured = false;
        if (CanCapture(piece, target))
        {
            pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
            captured = true;
            if (pieceToTake is {Color: ChessPiece.PieceColor.Black})
                _blackPieces.Remove(pieceToTake);
            else
                _whitePieces.Remove(pieceToTake);

            _pieces.Remove(pieceToTake);
        }
        
        var oldPosition = piece.Position;
        piece.Position = target;
        
        var inCheck = InCheck(piece.Color);
        
        piece.Position = oldPosition;
        
        if (captured)
        {
            if (pieceToTake is {Color: ChessPiece.PieceColor.Black})
                _blackPieces.Add(pieceToTake);
            else
                _whitePieces.Add(pieceToTake);

            _pieces.Add(pieceToTake);
        }

        return inCheck;
    }

    private void Castle(ChessPiece king, Vector2 target)
    {
        const int kingX = 4;
        const int kingCastlingDistance = 2;
        bool queenSideCastle = (int) target.X == kingX - kingCastlingDistance;
        int currentRookX = queenSideCastle ? LeftSide : RightSide;
        Vector2 currentRookPosition = new Vector2(currentRookX, king.Position.Y);

        var rook = _pieces.FirstOrDefault(p => 
            p.Position == currentRookPosition && 
            p.Type == ChessPiece.PieceType.Rook && 
            p.Color == king.Color && 
            !p.HasMoved);
        if (rook == null) return;
        
        // When castling, the rook moves to between the new king position and the old king position
        float rookTargetX = (target.X + king.Position.X) / 2;
        Vector2 rookTarget = new Vector2(rookTargetX, rook.Position.Y);
        
        Place(rook, rookTarget, false);
    }

    private bool CanCastle(ChessPiece king, Vector2 target)
    {
        const int kingX = 4;
        const int castlingDistance = 2;
        bool notAKing = king.Type != ChessPiece.PieceType.King;
        bool notCastling = Math.Abs((int) king.Position.X - (int) target.X) != castlingDistance;
        bool hasMoved = king.HasMoved;
        bool queenSideCastle = (int) target.X == kingX - castlingDistance;
        bool kingSideCastle = (int) target.X == kingX + castlingDistance;
        
        bool validRook = false;
        bool piecesBetween = false;
        foreach (ChessPiece piece in _pieces)
        {
            bool isRook = piece.Type == ChessPiece.PieceType.Rook;
            bool sameColor = piece.Color == king.Color;
            bool notMoved = !piece.HasMoved;
            bool onSameRow = (int) piece.Position.Y == (int) king.Position.Y;
            bool onQueenSide = (int) piece.Position.X == LeftSide;
            bool onKingSide = (int) piece.Position.X == RightSide;
            bool correctSide = (queenSideCastle && onQueenSide) || (kingSideCastle && onKingSide);
            bool onLeft = piece.Position.X is > LeftSide and < kingX;
            bool onRight = piece.Position.X is > kingX and < RightSide;
            bool betweenPieces = (queenSideCastle && onLeft) || (kingSideCastle && onRight);
            
            if (isRook && sameColor && notMoved && onSameRow && correctSide)
                validRook = true;

            if (betweenPieces && onSameRow)
                piecesBetween = true;
        }
        
        if (notAKing || notCastling || hasMoved ||
            !validRook || piecesBetween)
            return false;

        return true;
    }
    
    private static bool InBounds(Vector2 position)
    {
        bool inRank = position.Y is >= LeftSide and <= RightSide;
        bool inFile = position.X is >= TopSide and <= BottomSide;
        return inRank && inFile;
    }
    
    private bool InCheck(ChessPiece.PieceColor color)
    {
        var king = _pieces.FirstOrDefault(p => p.Type == ChessPiece.PieceType.King && p.Color == color);
        if (king == null) return false; // shouldn't happen because there is always a king unless the game is over
        
        return _pieces.Any(p => IsMoveValid(p, king.Position) && CanCapture(p, king.Position));
    }

    private bool CanCapture(ChessPiece piece, Vector2 target) 
    {
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        bool notCapturing = pieceToTake == null;
        bool sameColor = pieceToTake?.Color == piece.Color;
        bool isPawn = piece.Type == ChessPiece.PieceType.Pawn;
        bool movingStraight = (int) piece.Position.X == (int) target.X;
        bool canMove = IsMoveValid(piece, target);

        if (notCapturing || sameColor || !canMove ||
            (isPawn && movingStraight))
            return false;
        
        return true;
    }

    private bool IsBlocked(ChessPiece piece, Vector2 target)
    {
        var pointsBetween = PointsBetween(piece.Position, target);
        bool anyPieceBetween = false;
        bool isKnight = piece.Type == ChessPiece.PieceType.Knight;
        foreach (var betweenPiece in _pieces)
        {
            bool pieceIsBetween = pointsBetween.Any(point => point == betweenPiece.Position);
            if (pieceIsBetween)
                anyPieceBetween = true;
        }
        
        if (anyPieceBetween && !isKnight)
            return true;
        
        return false;
    }

    private static List<Vector2> PointsBetween(Vector2 start, Vector2 target)
    {
        // Bresenham's line algorithm
        var points = new List<Vector2>();

        // Calculate the difference between the x and y coordinates
        var deltaX = (int) Math.Abs(target.X - start.X);
        var deltaY = (int) Math.Abs(target.Y - start.Y);
        
        if (deltaX == 0 && deltaY == 0)
            return points;

        // Calculate the sign of the increment for the x and y coordinates
        var signX = start.X < target.X ? 1 : -1;
        var signY = start.Y < target.Y ? 1 : -1;

        // Calculate the error value
        var err = deltaX - deltaY;

        // Continue moving until the end point is reached
        while ((int) start.X != (int) target.X || (int) start.Y != (int) target.Y)
        {
            var e2 = err * 2;

            // Choose the direction with the smallest error value
            if (e2 > -deltaX)
            {
                err -= deltaY;
                start.X += signX;
            }

            if (e2 < deltaX)
            {
                err += deltaX;
                start.Y += signY;
            }

            points.Add(start);
        }

        // Just the points between the start and end, not including the start and end
        points.RemoveAt(points.Count - 1);
        return points;
    }

    private bool CanMove(ChessPiece piece, Vector2 target)
    {
        int deltaX = (int) Math.Abs(target.X - piece.Position.X);
        bool castling = piece.Type == ChessPiece.PieceType.King && deltaX == 2;
        bool canCastle = CanCastle(piece, target);
        bool invalidMove = !IsMoveValid(piece, target);
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        bool capturing = pieceToTake != null;
        bool inCheckAfterMove = InCheckAfterMove(piece, target);

        if (invalidMove || inCheckAfterMove ||
            (capturing && !CanCapture(piece, target)) ||
            (castling && !canCastle))
            return false;
        return true;
    }

    private bool IsMoveValid(ChessPiece piece, Vector2 target) // CanMove without the check for check to prevent infinite loop
    {
        int deltaX = (int) Math.Abs(target.X - piece.Position.X);
        int deltaY = (int) Math.Abs(target.Y - piece.Position.Y);
        bool outOfChessboard = !InBounds(target);
        bool pieceIllegalMove = !piece.CanMoveTo(target);
        bool isBlocked = IsBlocked(piece, target);
        bool castling = piece.Type == ChessPiece.PieceType.King && deltaX == 2;

        if (outOfChessboard || pieceIllegalMove || isBlocked ||
            (castling && !CanCastle(piece, target)))
            return false;
        
        if (piece.Type == ChessPiece.PieceType.Pawn)
        {
            var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
            bool capturing = pieceToTake != null;
            bool sameColor = pieceToTake?.Color == piece.Color;
            bool movingStraight = deltaX == 0;
            bool movingDiagonally = deltaX == 1 && deltaY == 1;
            
            if ((movingDiagonally && (!capturing || sameColor)) || 
                (movingStraight && capturing))
                return false;
        }
        
        // If all checks pass, the move is valid
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