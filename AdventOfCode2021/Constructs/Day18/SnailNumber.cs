﻿namespace AdventOfCode2021.Constructs.Day18
{
    public class SnailNumber
    {
        public SnailNumber? Parent { get; set; }

        public SnailNumber? Left { get; set; }
        public SnailNumber? Right { get; set; }

        public bool IsLeft { get; set; }
        public bool IsRight { get; set; }

        public int Depth { get; set; }
        public long LeftValue { get; set; }
        public long RightValue { get; set; }


        private void AddLeftValue(long value)
        {
            if (Left is not null)
            {
                Left.AddLeftValue(value);
            }
            else
            {
                LeftValue += value;
            }
        }

        private void AddRightValue(long value)
        {
            if (Right is not null)
            {
                Right.AddRightValue(value);
            }
            else
            {
                RightValue += value;
            }
        }

        public void AddDepth()
        {
            Depth++;
            if (Left is not null)
            {
                Left.AddDepth();
            }
            if (Right is not null)
            {
                Right.AddDepth();
            }
        }

        public void Reduce()
        {
            while(TryReduce())
            { }
        }

        public long GetMagnitude()
        {
            var left = Left is not null
                ? Left.GetMagnitude()
                : LeftValue;
            var right = Right is not null
                ? Right.GetMagnitude()
                : RightValue;
            
            return left * 3 + right * 2;
        }

        private bool TryReduce()
        {
            return TryExplode() || TrySplit();            
        }

        private bool TryExplode()
        {
            if (Depth < 4)
            {
                if (Left is not null && Left.TryExplode())
                {                    
                    return true;
                }
                else if (Right is not null && Right.TryExplode())
                {
                    return true;
                }
            }
            else
            {
                if (IsLeft)
                {
                    Parent!.ExplodeLeft(LeftValue, RightValue, true);
                }
                else
                {
                    Parent!.ExplodeRight(LeftValue, RightValue, true);
                }

                return true;
            }

            return false;
        }

        private void ExplodeRight(long left, long right, bool initial = false)
        {
            if (IsLeft)
            {
                if (Parent?.Right is not null)
                {
                    Parent.Right.AddLeftValue(right);
                }
                else if (Parent is not null)
                {
                    Parent.RightValue += right;
                }
            }
            else if (Parent is not null)
            {
                Parent.ExplodeRight(left, right);
            }
           

            if (initial)
            {
                if (Left is not null)
                {
                    Left.AddRightValue(left);
                }
                else
                {
                    LeftValue += left;
                }

                RightValue = 0;
                Right = null;
            }
        }

        private void ExplodeLeft(long left, long right, bool initial = false)
        {
            if (IsRight)
            {
                if (Parent?.Left is not null)
                {
                    Parent.Left.AddRightValue(left);
                }
                else if (Parent is not null)
                {
                    Parent.LeftValue += left;
                }
            }
            else if (Parent is not null)
            {
                Parent.ExplodeLeft(left, right);
            }

            if (initial)
            {
                if (Right is not null)
                {
                    Right.AddLeftValue(right);
                }
                else
                {
                    RightValue += right;
                }

                LeftValue = 0;
                Left = null;
            }
        }

        private bool TrySplit()
        {
            bool split = false;
            if (Left is not null && Left.TrySplit())
            {
                return true;
            }
            else if (LeftValue >= 10)
            {
                split = true;
                Left = new SnailNumber
                {
                    Parent = this,
                    Depth = Depth + 1,
                    LeftValue = (int)Math.Floor(LeftValue / 2D),
                    RightValue = (int)Math.Ceiling(LeftValue / 2D),
                    IsLeft = true
                };
                LeftValue = 0;
            }
            else if (Right is not null && Right.TrySplit())
            {
                return true;
            }
            else if (RightValue >= 10)
            {
                split = true;
                Right = new SnailNumber
                {
                    Parent = this,
                    Depth = Depth + 1,
                    LeftValue = (int)Math.Floor(RightValue / 2D),
                    RightValue = (int)Math.Ceiling(RightValue / 2D),
                    IsRight = true
                };
                RightValue = 0;
            }

            return split;
        }

        public override string ToString()
        {
            var left = Left is not null
                ? Left.ToString()
                : $"{LeftValue}";
            var right = Right is not null
                ? Right.ToString()
                : $"{RightValue}";
            return $"[{left},{right}]";
        }
    }
}