using System;
using System.Collections.Generic;
using System.Linq;
using Chess.ChessPieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Chess.ChessPiece;

namespace Chess;

public class ChessGame : Game
{
    private const int LeftSide = 0;
    private const int RightSide = 7;
    private const int TopSide = 0;
    private const int BottomSide = 7;

    private static Texture2D _chessBoard;

    private List<ChessPiece> _blackPieces;
    private List<ChessPiece> _whitePieces;
    private List<ChessPiece> _pieces;

    private int _maxSize;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private ChessPiece _pickedUpPiece;
    private MouseState _mouseState;

    private PieceColor _turn;
    
    private bool _lastMoveEnPassantEligible;
    private ChessPiece _lastMovedPiece;
    
    public ChessGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _turn = PieceColor.White; // White starts
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

        _blackPieces = new List<ChessPiece>
        {
            new Rook(PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
                new Position(0, 0)), 
            new Knight(PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
                new Position(1, 0)), 
            new Bishop(PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
                new Position(2, 0)), 
            new Queen(PieceColor.Black, Content.Load<Texture2D>("BlackQueen"), 
                new Position(3, 0)), 
            new King(PieceColor.Black, Content.Load<Texture2D>("BlackKing"), 
                new Position(4, 0)), 
            new Bishop(PieceColor.Black, Content.Load<Texture2D>("BlackBishop"), 
                new Position(5, 0)), 
            new Knight(PieceColor.Black, Content.Load<Texture2D>("BlackKnight"), 
                new Position(6, 0)), 
            new Rook(PieceColor.Black, Content.Load<Texture2D>("BlackRook"), 
                new Position(7, 0))
        };

        _whitePieces = new List<ChessPiece>
        {
            new Rook(PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
                new Position(0, 7)),
            new Knight(PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
                new Position(1, 7)),
            new Bishop(PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
                new Position(2, 7)),
            new Queen(PieceColor.White, Content.Load<Texture2D>("WhiteQueen"),
                new Position(3, 7)),
            new King(PieceColor.White, Content.Load<Texture2D>("WhiteKing"),
                new Position(4, 7)),
            new Bishop(PieceColor.White, Content.Load<Texture2D>("WhiteBishop"),
                new Position(5, 7)),
            new Knight(PieceColor.White, Content.Load<Texture2D>("WhiteKnight"),
                new Position(6, 7)),
            new Rook(PieceColor.White, Content.Load<Texture2D>("WhiteRook"),
                new Position(7, 7))
        };
        
        for (int i = 0; i < 8; i++)
        {
            _blackPieces.Add(new Pawn(PieceColor.Black, Content.Load<Texture2D>("BlackPawn"),
                new Position(i, 1)));
            _whitePieces.Add(new Pawn(PieceColor.White, Content.Load<Texture2D>("WhitePawn"),
                new Position(i, 6)));
        }

        _pieces = _blackPieces.Concat(_whitePieces).ToList();
    }

    protected override void Update(GameTime gameTime)
    {
        bool backButtonPressed = GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
        bool escapeKeyPressed = Keyboard.GetState().IsKeyDown(Keys.Escape);
        _mouseState = Mouse.GetState();
        var mouseClicked = _mouseState.LeftButton == ButtonState.Pressed;
        var targetSquare = ToChessGrid(_mouseState.X, _mouseState.Y);
        bool holdingPiece = _pickedUpPiece != null;
        bool mouseInBoardX = _mouseState.X > 0 && _mouseState.X < _maxSize;
        bool mouseInBoardY = _mouseState.Y > 0 && _mouseState.Y < _maxSize;
        bool mouseInBoard = mouseInBoardX && mouseInBoardY;
        bool isPieceUnderMouse = _pieces.Any(p => Equals(p.Position, targetSquare));

        if (backButtonPressed || escapeKeyPressed)
            Exit();
        
        if (mouseClicked && !holdingPiece && mouseInBoard && isPieceUnderMouse)
            PickUpPiece(targetSquare);
        else if (!mouseClicked && holdingPiece)
            PlacePiece(targetSquare);

        base.Update(gameTime);
    }

    private void PlacePiece(Position target)
    {
        Place(_pickedUpPiece, target);

        _pickedUpPiece.BeingDragged = false;
        _pickedUpPiece = null;
    }

    private void PickUpPiece(Position target)
    {
        _pickedUpPiece = _pieces.FirstOrDefault(p => Equals(p.Position, target));
        if (_pickedUpPiece != null) _pickedUpPiece.BeingDragged = true;
    }

    private Position ToChessGrid(Vector2 position)
    {
        var scale = _maxSize / 8f;
        return new Position((int) (position.X / scale), (int) (position.Y / scale));
    }
        
    private Vector2 ToScreenSpace(Position position)
    {
        var scale = _maxSize / 8f;
        return new Vector2(position.X * scale, position.Y * scale);
    }
    
    private Vector2 ToScreenSpace(Vector2 position)
    {
        var scale = _maxSize / 8f;
        return new Vector2(position.X * scale, position.Y * scale);
    }
    
    private float ToChessX(float position)
    {
        return ToChessGrid(new Vector2(position, 0)).X;
    }
    
    private Position ToChessGrid(float x, float y)
    {
        return ToChessGrid(new Vector2(x, y));
    }

    private float ToScreenX(float position)
    {
        return ToScreenSpace(new Vector2(position, 0)).X;
    }
    
    private Vector2 ToScreenSpace(float x, float y)
    {
        return ToScreenSpace(new Vector2(x, y));
    }
    
    private void Place(ChessPiece piece, Position target, bool changeTurn = true)
    {
        if (!CanMove(piece, target)) return;
        if (CanCastle(piece, target)) Castle(piece, target);
        if (CanEnPassant(piece, target)) RemovePiece(_lastMovedPiece.Position);
        else if (CanCapture(piece, target)) RemovePiece(target);
        
        MovePiece(piece, target);

        if (ShouldPromotePawn(piece)) piece = PromotePawn(piece);

        // if (IsCheckmate()) ShowCheckmatePrompt(); // CheckmatePrompt will be a standard MonoGame text box
        
        // if (IsStalemate()) ShowStalematePrompt();

        if (changeTurn) ChangeTurn();
        
        // TODO: Add checkmate dialog
    }

    private bool IsStalemate()
    {
        King king = (King) _pieces.FirstOrDefault(p => p is King && p.Color == _turn); // TODO: Loop through both kings
        if (king == null) return false; // Shouldn't ever happen
        Position[] possibleMoves = king.GetPossibleMoves();
        
        foreach (var move in possibleMoves)
            if (CanMove(king, move)) return false;

        return true;
    }

    private static bool ShouldPromotePawn(ChessPiece piece)
    {
        bool isPawn = piece is Pawn;
        bool onBottomRank = piece.Position.Y == BottomSide;
        bool onTopRank = piece.Position.Y == TopSide;
        bool onLastRank = onBottomRank || onTopRank;
        return isPawn && onLastRank;
    }

    private ChessPiece PromotePawn(ChessPiece piece)
    {
        // TODO: Add choice for promotion
        Texture2D texture = piece.Color == PieceColor.Black
            ? Content.Load<Texture2D>("BlackQueen")
            : Content.Load<Texture2D>("WhiteQueen");
        Queen queen = new Queen(piece.Color, texture, piece.Position);
        return queen;
    }

    private void ChangeTurn()
    {
        if (_turn == PieceColor.White)
            _turn = PieceColor.Black;
        else
            _turn = PieceColor.White;
    }

    private void MovePiece(ChessPiece piece, Position target)
    {
        bool isPawn = piece is Pawn;
        bool movedTwo = Math.Abs(target.Y - piece.Position.Y) == 2;

        piece.Position = target;

        if (!piece.HasMoved)
            piece.HasMoved = true;
        
        _lastMoveEnPassantEligible = isPawn && movedTwo;
        _lastMovedPiece = piece;
    }

    private ChessPiece RemovePiece(Position target)
    {
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        if (pieceToTake is {Color: PieceColor.Black})
            _blackPieces.Remove(pieceToTake);
        else
            _whitePieces.Remove(pieceToTake);

        _pieces.Remove(pieceToTake);
        
        return pieceToTake;
    }
    
    private void AddPiece(ChessPiece piece)
    {
        if (piece is {Color: PieceColor.Black})
            _blackPieces.Add(piece);
        else
            _whitePieces.Add(piece);

        _pieces.Add(piece);
    }

    private bool InCheckAfterMove(ChessPiece piece, Position target)
    {
        bool enPassant = CanEnPassant(piece, target);
        
        // Perform the move
        ChessPiece pieceToTake = null;
        var willCapture = CanCapture(piece, target);
        if (willCapture)
        {
            if (enPassant) pieceToTake = RemovePiece(_lastMovedPiece.Position);
            else pieceToTake = RemovePiece(target);
        }

        var oldPosition = piece.Position;
        piece.Position = target;
        ChangeTurn();
        
        // Check if the move puts the player in check
        var inCheck = InCheck(piece.Color);
        
        // Undo the move
        piece.Position = oldPosition;
        ChangeTurn();
        
        if (willCapture)
            AddPiece(pieceToTake);

        return inCheck;
    }

    private void Castle(ChessPiece king, Position target)
    {
        const int kingX = 4;
        const int kingCastlingDistance = 2;
        bool queenSideCastle = target.X == kingX - kingCastlingDistance;
        int currentRookX = queenSideCastle ? LeftSide : RightSide;
        Position currentRookPosition = new Position(currentRookX, king.Position.Y);

        var rook = _pieces.FirstOrDefault(p => 
            p.Position == currentRookPosition && 
            p is Rook && 
            p.Color == king.Color && 
            !p.HasMoved);
        if (rook == null) return;
        
        // When castling, the rook moves to between the new king position and the old king position
        int rookTargetX = (target.X + king.Position.X) / 2;
        Position rookTarget = new Position(rookTargetX, rook.Position.Y);
        
        Place(rook, rookTarget, false);
    }

    private bool CanCastle(ChessPiece king, Position target)
    {
        const int kingX = 4;
        const int castlingDistance = 2;
        bool notAKing = king is not King;
        bool notCastling = Math.Abs(king.Position.X - target.X) != castlingDistance;
        bool hasMoved = king.HasMoved;
        bool queenSideCastle = target.X == kingX - castlingDistance;
        bool kingSideCastle = target.X == kingX + castlingDistance;
        
        bool validRook = false;
        bool piecesBetween = false;
        foreach (ChessPiece piece in _pieces)
        {
            bool isRook = piece is Rook;
            bool sameColor = piece.Color == king.Color;
            bool notMoved = !piece.HasMoved;
            bool onSameRow = piece.Position.Y == king.Position.Y;
            bool onQueenSide = piece.Position.X == LeftSide;
            bool onKingSide = piece.Position.X == RightSide;
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
    
    private static bool InBounds(Position position)
    {
        bool inRank = position.Y is >= LeftSide and <= RightSide;
        bool inFile = position.X is >= TopSide and <= BottomSide;
        return inRank && inFile;
    }
    
    private bool InCheck(PieceColor color)
    {
        var king = _pieces.FirstOrDefault(p => p is King && p.Color == color);
        if (king == null) return false; // shouldn't happen because there is always a king unless the game is over
        return _pieces.Any(p => CanCapture(p, king.Position));
    }

    private bool CanCapture(ChessPiece piece, Position target) 
    {
        var pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        if (CanEnPassant(piece, target)) pieceToTake = _lastMovedPiece;
        bool notCapturing = pieceToTake == null;
        bool sameColor = pieceToTake?.Color == piece.Color;
        bool isPawn = piece is Pawn;
        bool movingStraight = piece.Position.X == target.X;
        bool canMove = IsMoveValid(piece, target);

        if (notCapturing || sameColor || !canMove ||
            (isPawn && movingStraight))
            return false;
        
        return true;
    }

    private bool IsBlocked(ChessPiece piece, Position target)
    {
        var pointsBetween = PointsBetween(piece.Position, target);
        bool anyPieceBetween = false;
        bool isKnight = piece is Knight;
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

    private static List<Position> PointsBetween(Position start, Position target)
    {
        // Bresenham's line algorithm
        var points = new List<Position>();

        // Calculate the difference between the x and y coordinates
        var deltaX = Math.Abs(target.X - start.X);
        var deltaY = Math.Abs(target.Y - start.Y);
        
        if (deltaX == 0 && deltaY == 0)
            return points;

        // Calculate the sign of the increment for the x and y coordinates
        var signX = start.X < target.X ? 1 : -1;
        var signY = start.Y < target.Y ? 1 : -1;

        // Calculate the error value
        var err = deltaX - deltaY;

        // Continue moving until the end point is reached
        while (start.X != target.X || start.Y != target.Y)
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

    private bool CanMove(ChessPiece piece, Position target)
    {
        int deltaX = Math.Abs(target.X - piece.Position.X);
        bool test = piece.GetType() == typeof(King);
        bool castling = piece is King && deltaX == 2;
        bool canCastle = CanCastle(piece, target);
        bool invalidMove = !IsMoveValid(piece, target);
        ChessPiece pieceToTake;
        if (CanEnPassant(piece, target)) pieceToTake = _lastMovedPiece;
        else pieceToTake = _pieces.FirstOrDefault(p => p.Position == target);
        bool capturing = pieceToTake != null;
        bool inCheckAfterMove = InCheckAfterMove(piece, target);

        if (invalidMove || inCheckAfterMove ||
            (capturing && !CanCapture(piece, target)) ||
            (castling && !canCastle))
            return false;
        return true;
    }

    private bool CanEnPassant(ChessPiece piece, Position target)
    {
        int deltaX = Math.Abs(target.X - piece.Position.X);
        int deltaY = Math.Abs(target.Y - piece.Position.Y);
        bool isPawn = piece is Pawn;
        bool movingDiagonally = deltaX == 1 && deltaY == 1;
        
        if (_lastMovedPiece == null) return false;
        
        var lastMoveDestination = _lastMovedPiece.Position;
        bool validX = lastMoveDestination.X == target.X;
        bool validY = lastMoveDestination.Y == piece.Position.Y;
        var lastMoveAdjacent = validX && validY;
        
        bool enPassantEligible = _lastMoveEnPassantEligible && lastMoveAdjacent && isPawn && movingDiagonally;
        return enPassantEligible;
    }

    private bool IsMoveValid(ChessPiece piece, Position target) // CanMove without the check for check to prevent infinite loop
    {
        int deltaX = Math.Abs(target.X - piece.Position.X);
        int deltaY = Math.Abs(target.Y - piece.Position.Y);
        bool outOfChessboard = !InBounds(target);
        bool pieceIllegalMove = !piece.CanMoveTo(target);
        bool isBlocked = IsBlocked(piece, target);
        bool castling = piece is King && deltaX == 2;
        bool wrongTurn = piece.Color != _turn;
        bool notMoving = deltaX == 0 && deltaY == 0;

        if (CanEnPassant(piece, target)) // En passant is a special case
            return true;

        if (notMoving || outOfChessboard || pieceIllegalMove || isBlocked || wrongTurn ||
            (castling && !CanCastle(piece, target)))
            return false;
        
        if (piece is Pawn)
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
                    new Rectangle((int) ToScreenX(piece.Position.X), 
                        (int) ToScreenX(piece.Position.Y), 
                        (int) ToScreenX(1), (int) ToScreenX(1)),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0.1f);
            else
                _spriteBatch.Draw(piece.Texture,
                    new Rectangle(_mouseState.X - (int) ToScreenX(0.5f), 
                        _mouseState.Y - (int) ToScreenX(0.5f), 
                        (int) ToScreenX(1), (int) ToScreenX(1)),
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