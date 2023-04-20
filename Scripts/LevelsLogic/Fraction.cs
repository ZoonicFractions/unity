using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fraction 
{
    public int num, den;
    private static int maxDen = 10;
    public Fraction(int num, int den)
    {
        if (den == 0) throw new ArgumentException("Division entre cero");
        if (den < 0)
        {
            den *= -1;
            num *= -1;
        }
        this.num = num;
        this.den = den;
        ReduceFraction();
    }
    public static void SetMaxDen(int maxDen) 
    {
        Fraction.maxDen = maxDen;
    }
    public Fraction() : this(0, 1) { }

    public static Fraction operator + (Fraction a, Fraction b)
    {
        int r1 = a.num * b.den + b.num * a.den;
        int r2 = a.den * b.den;
        return new Fraction(r1, r2);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        int r1 = a.num * b.den - b.num * a.den;
        int r2 = a.den * b.den;
        return new Fraction(r1, r2);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        int r1 = a.num * b.num;
        int r2 = a.den * b.den;
        return new Fraction(r1, r2);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        int r1 = a.num * b.den;
        int r2 = a.den * b.num;
        return new Fraction(r1, r2);
    }

    public void ReduceFraction()
    {
        int d;
        d = gcd(num, den);

        num /= d;
        den /= d;

        if(den < 0)
        {
            num *= -1;
            den *= -1;
        }
    }

    public int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);

    }

    public static bool operator == (Fraction f1, Fraction f2)
    {
        f1.ReduceFraction();
        f2.ReduceFraction();
        return f1.num == f2.num && f1.den == f2.den;
    }
    public static bool operator !=(Fraction f1, Fraction f2)
    {
        f1.ReduceFraction();
        f2.ReduceFraction();
        return f1.num != f2.num ^ f1.den != f2.den;
    }

    public static Fraction GenerateRandomFraction()
    {
        int num, den;
        num = Random.Range(-maxDen, maxDen);
        do
        {
            den = Random.Range(-maxDen, maxDen);
        } while (den == 0);
        return new Fraction(num, den);
    }

    public static Fraction operator *(Fraction f, int n)
    {
        f.num *= n;
        f.ReduceFraction();
        return f;
    }

    public static Fraction operator *(int n, Fraction f)
    {
        f.num *= n;
        f.ReduceFraction();
        return f;
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        return this == (Fraction) obj;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
